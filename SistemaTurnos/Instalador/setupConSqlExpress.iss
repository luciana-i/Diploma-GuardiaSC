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
UninstallDisplayName={#MyAppName}
UninstallDisplayIcon={app}\{#MyAppExeName}
; Requiere privilegios elevados para registrar servicios de SQL Server
PrivilegesRequired=admin

[Files]
Source: "..\bin\Release\{#MyAppExeName}"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\bin\Release\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "..\..\DAL\script_base.sql"; DestDir: "{app}"; Flags: ignoreversion
Source: "Assets\icono.ico"; DestDir: "{app}"; Flags: ignoreversion

; Instalador offline de SQL Server Express (subcarpeta Redist)
Source: "Redist\SQLEXPR_x64_ENU.exe"; DestDir: "{tmp}"; Flags: deleteafterinstall ignoreversion

[Icons]
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; IconFilename: "{app}\icono.ico"

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "Ejecutar la aplicación ahora"; Flags: nowait postinstall skipifsilent

[Code]
var
  NombreServidor, LogPath: String;
  RequiereInstalarSQL: Boolean;

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
  
  EjecutoBien := Exec(ExpandConstant('{cmd}'), '/c sqlcmd -S "' + Servidor + '" -E -Q "SELECT 1" -b -l 5', '', SW_HIDE, ewWaitUntilTerminated, ResultCode);
  
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

function DetectarInstanciaExistente(): String;
var
  ResultCode, i, RootKey: Integer;
  NombresInstancias: TArrayOfString;
begin
  Result := '';
  EscribirLog('--- Buscando instancias en Registro de Windows ---');

  if IsWin64 then RootKey := HKLM64 else RootKey := HKLM;

  if RegGetValueNames(RootKey, 'SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL', NombresInstancias) then
  begin
    // 1. Buscar SQLEXPRESS
    for i := 0 to GetArrayLength(NombresInstancias) - 1 do
    begin
      if CompareText(NombresInstancias[i], 'SQLEXPRESS') = 0 then
      begin
        Exec('net', 'start MSSQL$SQLEXPRESS', '', SW_HIDE, ewWaitUntilTerminated, ResultCode);
        if ProbarConexionSQL('.\SQLEXPRESS') then
        begin
          Result := '.\SQLEXPRESS';
          EscribirLog('¡ÉXITO! .\SQLEXPRESS responde.');
          Exit;
        end;
      end;
    end;

    // 2. Buscar MSSQLSERVER (instancia predeterminada)
    for i := 0 to GetArrayLength(NombresInstancias) - 1 do
    begin
      if CompareText(NombresInstancias[i], 'MSSQLSERVER') = 0 then
      begin
        Exec('net', 'start MSSQLSERVER', '', SW_HIDE, ewWaitUntilTerminated, ResultCode);
        if ProbarConexionSQL('.') then
        begin
          Result := '.';
          EscribirLog('¡ÉXITO! MSSQLSERVER (.) responde.');
          Exit;
        end;
      end;
    end;
  end;
end;

function InitializeSetup(): Boolean;
begin
  Result := True;
  NombreServidor := '';
  LogPath := '';
  RequiereInstalarSQL := False;

  EscribirLog('=== INICIANDO VALIDACIÓN DE ENTORNO SQL ===');

  NombreServidor := DetectarInstanciaExistente();

  // Si no hay SQL Server, se avisa al usuario antes de entrar al Wizard
  if NombreServidor = '' then
  begin
    EscribirLog('No se encontró SQL Server instalado. Se programará su instalación.');
    if MsgBox('No se detectó Microsoft SQL Server en el equipo.' + #13#10 + #13#10 +
              'El instalador configurará automáticamente SQL Server Express durante el proceso de instalación.' + #13#10 +
              'Esta etapa requerirá entre 5 y 10 minutos.' + #13#10#13#10 +
              '¿Desea continuar?', mbConfirmation, MB_YESNO) = IDYES then
    begin
      RequiereInstalarSQL := True;
    end
    else
    begin
      Result := False;
    end;
  end;
end;

// Esta función se ejecuta con la ventana del asistente visible en la pantalla "Preparando la instalación"
function PrepareToInstall(var NeedsRestart: Boolean): String;
var
  ResultCode: Integer;
  SetupExePath, Argumentos: String;
begin
  Result := '';

  if RequiereInstalarSQL then
  begin
    // Actualiza el texto en la ventana del asistente
    WizardForm.PreparingLabel.Caption := 'Instalando Microsoft SQL Server Express en segundo plano.' + #13#10 +
                                         'Por favor espere, esta operación demorará entre 5 y 10 minutos...';
    WizardForm.PreparingLabel.Visible := True;
    WizardForm.Refresh;

    EscribirLog('Extrayendo instalador de SQL Express...');
    ExtractTemporaryFile('SQLEXPR_x64_ENU.exe');
    SetupExePath := ExpandConstant('{tmp}\SQLEXPR_x64_ENU.exe');

    Argumentos := '/q /ACTION=Install /FEATURES=SQL /INSTANCENAME=SQLEXPRESS ' +
                  '/SQLSYSADMINACCOUNTS="BUILTIN\Administrators" ' +
                  '/IACCEPTSQLSERVERLICENSETERMS /TCPENABLED=1 /NPENABLED=1';

    EscribirLog('Ejecutando setup de SQL Express...');
    if Exec(SetupExePath, Argumentos, '', SW_HIDE, ewWaitUntilTerminated, ResultCode) then
    begin
      EscribirLog('Instalador finalizado con código: ' + IntToStr(ResultCode));
      if (ResultCode = 0) or (ResultCode = 3010) then
      begin
        Sleep(5000);
        Exec('net', 'start MSSQL$SQLEXPRESS', '', SW_HIDE, ewWaitUntilTerminated, ResultCode);
        
        if ProbarConexionSQL('.\SQLEXPRESS') then
        begin
          NombreServidor := '.\SQLEXPRESS';
          EscribirLog('¡Instancia .\SQLEXPRESS operativa!');
        end
        else
        begin
          Result := 'SQL Server finalizó la instalación pero la instancia .\SQLEXPRESS no respondió a la conexión.';
        end;
      end
      else
      begin
        Result := 'Error al instalar Microsoft SQL Server Express. Código de salida: ' + IntToStr(ResultCode);
      end;
    end
    else
    begin
      Result := 'No se pudo iniciar el instalador de SQL Server Express.';
    end;
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
      EscribirLog('El sistema destino SOPORTA TrustServerCertificate.');
      JsonContent := '{ "ConnectionString": "Data Source=' + ServidorJson + ';Initial Catalog=Proyecto_Ing_softw;Integrated Security=True;TrustServerCertificate=True" }';
    end
    else
    begin
      EscribirLog('El sistema destino NO soporta TrustServerCertificate.');
      JsonContent := '{ "ConnectionString": "Data Source=' + ServidorJson + ';Initial Catalog=Proyecto_Ing_softw;Integrated Security=True" }';
    end;

    SaveStringToFile(ConfigJsonPath, JsonContent, False);

    // Dropear la base de datos si existiera previamente para garantizar instalación limpia
    Exec('sqlcmd', '-S "' + NombreServidor + '" -E -Q "IF EXISTS (SELECT name FROM sys.databases WHERE name = N''Proyecto_Ing_softw'') BEGIN ALTER DATABASE [Proyecto_Ing_softw] SET SINGLE_USER WITH ROLLBACK IMMEDIATE; DROP DATABASE [Proyecto_Ing_softw]; END"', '', SW_HIDE, ewWaitUntilTerminated, ResultCode);

    // Ejecutar el script SQL para crear la estructura de tablas y datos
    if FileExists(SqlScriptPath) then
    begin
      Exec('sqlcmd', '-S "' + NombreServidor + '" -E -i "' + SqlScriptPath + '" -o "' + AppDir + '\Log_SQL.txt"', '', SW_HIDE, ewWaitUntilTerminated, ResultCode);
    end;
  end;
end;