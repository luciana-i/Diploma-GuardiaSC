#define MyAppName "GuardiaSC"
#define MyAppVersion "1.0.0"
#define MyAppExeName "SistemaTurnos.exe"

[Setup]
AppName={#MyAppName}
AppVersion={#MyAppVersion}
DefaultDirName={autopf}\{#MyAppName}
DefaultGroupName={#MyAppName}
OutputDir=..\InstaladorFinal
OutputBaseFilename=Instalador_Proyecto_Facultad
Compression=lzma
SolidCompression=yes
WizardStyle=modern
SetupIconFile=Assets\icono.ico

[Files]
Source: "..\bin\Release\{#MyAppExeName}"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\bin\Release\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "..\..\DAL\script_base.sql"; DestDir: "{app}"; Flags: ignoreversion
Source: "Assets\icono.ico"; DestDir: "{app}"; Flags: ignoreversion

[Icons]
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; IconFilename: "{app}\icono.ico"

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "Ejecutar la aplicación ahora"; Flags: nowait postinstall skipifsilent

[Code]
var
  InstanciaDetectada, NombreServidor, LogPath: String;

procedure EscribirLog(Mensaje: String);
begin
  if LogPath = '' then
    LogPath := ExpandConstant('{src}\Seguimiento_SQL.txt');
  SaveStringToFile(LogPath, Mensaje + #13#10, True);
end;

function ProbarConexionSQL(Servidor: String): Boolean;
var
  ResultCode: Integer;
  EjecutoBien: Boolean;
begin
  ResultCode := -1; 
  EscribirLog('-> HACIENDO PING CON SQLCMD A: ' + Servidor);
  
  EjecutoBien := Exec(ExpandConstant('{cmd}'), '/c sqlcmd -S "' + Servidor + '" -E -Q "SELECT 1" -b -l 3', '', SW_HIDE, ewWaitUntilTerminated, ResultCode);
  
  if EjecutoBien then
  begin
    EscribirLog('   Comando lanzado. Código de respuesta de SQL (0 = Éxito): ' + IntToStr(ResultCode));
    Result := (ResultCode = 0);
  end
  else
  begin
    EscribirLog('   Fallo del sistema: CMD.exe no pudo ejecutarse.');
    Result := False;
  end;
end;

function SoportaTrustServerCertificate(): Boolean;
var
  ResultCode: Integer;
begin
  Exec('powershell.exe', '-NoProfile -ExecutionPolicy Bypass -Command "try { $conn = New-Object System.Data.SqlClient.SqlConnection; $conn.ConnectionString = ''Data Source=.;Integrated Security=True;TrustServerCertificate=True''; exit 0 } catch { exit 1 }"', '', SW_HIDE, ewWaitUntilTerminated, ResultCode);
  Result := (ResultCode = 0);
end;

function InitializeSetup(): Boolean;
var
  ResultCode, i, RootKey: Integer;
  NombresInstancias: TArrayOfString;
begin
  Result := True;
  InstanciaDetectada := '';
  NombreServidor := '';
  LogPath := '';

  EscribirLog('=== INICIANDO DETECCIÓN DE SQL SERVER ===');

  if IsWin64 then RootKey := HKLM64 else RootKey := HKLM;

  if RegGetValueNames(RootKey, 'SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL', NombresInstancias) then
  begin
    EscribirLog('--- FASE 1: BUSCANDO SQLEXPRESS ---');
    for i := 0 to GetArrayLength(NombresInstancias) - 1 do
    begin
      if CompareText(NombresInstancias[i], 'SQLEXPRESS') = 0 then
      begin
        Exec('net', 'start MSSQL$SQLEXPRESS', '', SW_HIDE, ewWaitUntilTerminated, ResultCode);
        if (ResultCode = 0) or (ResultCode = 2) then
        begin
          if ProbarConexionSQL('.\SQLEXPRESS') then
          begin
            NombreServidor := '.\SQLEXPRESS';
            EscribirLog('¡ÉXITO! .\SQLEXPRESS responde.');
            Break;
          end;
        end;
      end;
    end;

    if NombreServidor = '' then
    begin
      EscribirLog('--- FASE 2: BUSCANDO MSSQLSERVER ---');
      for i := 0 to GetArrayLength(NombresInstancias) - 1 do
      begin
        if CompareText(NombresInstancias[i], 'MSSQLSERVER') = 0 then
        begin
          Exec('net', 'start MSSQLSERVER', '', SW_HIDE, ewWaitUntilTerminated, ResultCode);
          if (ResultCode = 0) or (ResultCode = 2) then
          begin
            if ProbarConexionSQL('.') then
            begin
              NombreServidor := '.';
              EscribirLog('¡ÉXITO! MSSQLSERVER (.) responde.');
              Break;
            end;
          end;
        end;
      end;
    end;
  end;

  if NombreServidor = '' then
  begin
    MsgBox('Este sistema requiere SQL Server para funcionar correctamente.', mbCriticalError, MB_OK);
    Result := False;
    Exit;
  end;
end;

procedure CurStepChanged(CurStep: TSetupStep);
var
  ResultCode: Integer;
  AppDir, SqlScriptPath, ConfigJsonPath, JsonContent, ServidorJson: String;
begin
  if CurStep = ssPostInstall then
  begin
    AppDir := ExpandConstant('{app}');
    SqlScriptPath := AppDir + '\script_base.sql';
    ConfigJsonPath := AppDir + '\appsettings.json';

    ServidorJson := NombreServidor;
    StringChange(ServidorJson, '\', '\\');

    if SoportaTrustServerCertificate() then
    begin
      EscribirLog('El sistema destino SOPORTA TrustServerCertificate. Agregándolo al JSON.');
      JsonContent := '{ "ConnectionString": "Data Source=' + ServidorJson + ';Initial Catalog=Proyecto_Ing_softw;Integrated Security=True;TrustServerCertificate=True" }';
    end
    else
    begin
      EscribirLog('El sistema destino NO soporta TrustServerCertificate. Omitiéndolo del JSON.');
      JsonContent := '{ "ConnectionString": "Data Source=' + ServidorJson + ';Initial Catalog=Proyecto_Ing_softw;Integrated Security=True" }';
    end;

    SaveStringToFile(ConfigJsonPath, JsonContent, False);

    Exec('sqlcmd', '-S "' + NombreServidor + '" -E -Q "IF EXISTS (SELECT name FROM sys.databases WHERE name = N''Proyecto_Ing_softw'') BEGIN ALTER DATABASE [Proyecto_Ing_softw] SET SINGLE_USER WITH ROLLBACK IMMEDIATE; DROP DATABASE [Proyecto_Ing_softw]; END"', '', SW_HIDE, ewWaitUntilTerminated, ResultCode);

    if FileExists(SqlScriptPath) then
    begin
      Exec('sqlcmd', '-S "' + NombreServidor + '" -E -i "' + SqlScriptPath + '" -o "' + AppDir + '\Log_SQL.txt"', '', SW_HIDE, ewWaitUntilTerminated, ResultCode);
    end;
  end;
end;