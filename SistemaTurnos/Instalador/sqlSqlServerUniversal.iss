#define MyAppName "GuardiaSC"
#define MyAppVersion "1.0.0"
#define MyAppExeName "SistemaTurnos.exe"

using System;
using System.Drawing;
using System.Windows.Forms;

[Setup]
AppName ={#MyAppName}
AppVersion ={#MyAppVersion}
DefaultDirName ={ autopf}\{#MyAppName}
DefaultGroupName ={#MyAppName}
OutputDir = ..\InstaladorFinal
OutputBaseFilename = Instalador_Proyecto_Facultad
Compression = lzma
SolidCompression = yes
WizardStyle = modern
SetupIconFile = Assets\icono.ico
UninstallDisplayName ={#MyAppName}
UninstallDisplayIcon={app}\{#MyAppExeName}
; Privilegios elevados obligatorios para levantar servicios de base de datos
PrivilegesRequired = admin

[Files]
Source: "..\bin\Release\{#MyAppExeName}"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\bin\Release\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "..\..\DAL\script_base.sql"; DestDir: "{app}"; Flags: ignoreversion
Source: "Assets\icono.ico"; DestDir: "{app}"; Flags: ignoreversion

; Instalador offline de SQL Server Express(subcarpeta Redist)
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
                EscribirLog('-> HACIENDO PING A: ' + Servidor);

                // Se prueba conexión rápida con sqlcmd
            EjecutoBien:= Exec(ExpandConstant('{cmd}'), '/c sqlcmd -S "' + Servidor + '" -E -Q "SELECT 1" -b -l 5', '', SW_HIDE, ewWaitUntilTerminated, ResultCode);

                if EjecutoBien then
                begin
    EscribirLog('   Código de respuesta: ' + IntToStr(ResultCode));
            Result:= (ResultCode = 0);
                end
  else
                    begin
    EscribirLog('   sqlcmd no disponible o falló ejecución. Probando vía PowerShell...');
                // Alternativa si el equipo no tiene sqlcmd en el PATH
                Exec('powershell.exe', '-NoProfile -Command "try { $c = New-Object System.Data.SqlClient.SqlConnection(''Server=' + Servidor + ';Integrated Security=True''); $c.Open(); $c.Close(); exit 0 } catch { exit 1 }"', '', SW_HIDE, ewWaitUntilTerminated, ResultCode);
            Result:= (ResultCode = 0);
                end;
                end;

                function SoportaTrustServerCertificate(): Boolean;
                var
                  ResultCode: Integer;
                begin
  Exec('powershell.exe', '-NoProfile -ExecutionPolicy Bypass -Command "try { $conn = New-Object System.Data.SqlClient.SqlConnection; $conn.ConnectionString = ''Data Source=.;Integrated Security=True;TrustServerCertificate=True''; exit 0 } catch { exit 1 }"', '', SW_HIDE, ewWaitUntilTerminated, ResultCode);
            Result:= (ResultCode = 0);
                end;

                function DetectarInstanciaExistente(): String;
                var
                  ResultCode, i, RootKey: Integer;
            NombresInstancias: TArrayOfString;
                begin
                  Result := '';
                EscribirLog('--- Buscando instancias instaladas ---');

                if IsWin64 then RootKey := HKLM64 else RootKey:= HKLM;

                if RegGetValueNames(RootKey, 'SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL', NombresInstancias) then
                begin
    // 1. SQLEXPRESS
    for i := 0 to GetArrayLength(NombresInstancias) - 1 do
                    begin
      if CompareText(NombresInstancias[i], 'SQLEXPRESS') = 0 then
      begin
        Exec('net', 'start MSSQL$SQLEXPRESS', '', SW_HIDE, ewWaitUntilTerminated, ResultCode);
                if ProbarConexionSQL('.\SQLEXPRESS') then
                begin
          Result:= '.\SQLEXPRESS';
                EscribirLog('¡Instancia .\SQLEXPRESS detectada y activa!');
                Exit;
                end;
                end;
                end;

                // 2. Instancia por defecto
                for i := 0 to GetArrayLength(NombresInstancias) - 1 do
                    begin
      if CompareText(NombresInstancias[i], 'MSSQLSERVER') = 0 then
      begin
        Exec('net', 'start MSSQLSERVER', '', SW_HIDE, ewWaitUntilTerminated, ResultCode);
                if ProbarConexionSQL('.') then
                begin
          Result:= '.';
                EscribirLog('¡Instancia por defecto (.) detectada y activa!');
                Exit;
                end;
                end;
                end;
                end;
                end;

                function InitializeSetup(): Boolean;
                begin
                  Result := True;
            NombreServidor:= '';
            LogPath:= '';
            RequiereInstalarSQL:= False;

                EscribirLog('=== VALIDANDO ENTORNO SQL ===');

            NombreServidor:= DetectarInstanciaExistente();

                if NombreServidor = '' then
                begin
    EscribirLog('No se detectó SQL Server. Solicitando confirmación...');
                if MsgBox('No se detectó Microsoft SQL Server instalado en este equipo.' + #13#10 + #13#10 +
              'El instalador configurará automáticamente SQL Server Express de manera offline.' + #13#10 +
              'Esta etapa requerirá unos minutos.' + #13#10#13#10 +
              '¿Desea continuar?', mbConfirmation, MB_YESNO) = IDYES then
    begin
      RequiereInstalarSQL:= True;
                end
    else
                    begin
                      Result := False;
                end;
                end;
                end;

                function PrepareToInstall(var NeedsRestart: Boolean): String;
                var
                  ResultCode: Integer;
                SetupExePath, Argumentos: String;
                begin
                  Result := '';

                if RequiereInstalarSQL then
                begin
              
                  WizardForm.PreparingLabel.Height := ScaleY(55);
                WizardForm.PreparingLabel.Caption := 'Instalando Microsoft SQL Server Express en segundo plano.' + #13#10 +
                                         'Esta etapa demorará entre 4 y 8 minutos. Por favor espere...';
                WizardForm.PreparingLabel.Visible := True;
                WizardForm.Refresh;

                EscribirLog('Extrayendo instalador offline...');
                ExtractTemporaryFile('SQLEXPR_x64_ENU.exe');
            SetupExePath:= ExpandConstant('{tmp}\SQLEXPR_x64_ENU.exe');

                // Parámetros universales:
                // Se añade como administrador el usuario local activo sin importar idioma ni dominio
            Argumentos:= '/q /ACTION=Install /FEATURES=SQL /INSTANCENAME=SQLEXPRESS ' +
                          '/SQLSYSADMINACCOUNTS="' + ExpandConstant('{%USERDOMAIN}\{%USERNAME%}') + '" ' +
                          '/SECURITYMODE=SQL /SAPWD="SqlAdmin2024!" ' +
                          '/IACCEPTSQLSERVERLICENSETERMS /TCPENABLED=1 /NPENABLED=1';

                EscribirLog('Ejecutando instalación desatendida de SQL Express...');
                if Exec(SetupExePath, Argumentos, '', SW_HIDE, ewWaitUntilTerminated, ResultCode) then
                begin
      EscribirLog('Setup finalizado con código: ' + IntToStr(ResultCode));

                // 0 = Éxito, 3010 = Éxito con reinicio pendiente
                if (ResultCode = 0) or(ResultCode = 3010) then
                begin
          
                  Sleep(4000);
                Exec('net', 'start MSSQL$SQLEXPRESS', '', SW_HIDE, ewWaitUntilTerminated, ResultCode);

                if ProbarConexionSQL('.\SQLEXPRESS') then
                begin
          NombreServidor:= '.\SQLEXPRESS';
                EscribirLog('¡Instancia .\SQLEXPRESS lista para usar!');
                end
        else
                    begin
                      Result := 'SQL Server finalizó pero la instancia .\SQLEXPRESS no respondió a la prueba de conexión.';
                end;
                end
      else
                    begin
                      Result := 'Error al instalar Microsoft SQL Server Express. Código: ' + IntToStr(ResultCode);
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
                AppDir, SqlScriptPath, ConfigJsonPath, JsonContent, ServidorJson, PsCommand: String;
                begin
  if CurStep = ssPostInstall then
  begin
    AppDir:= ExpandConstant('{app}');
            SqlScriptPath:= AppDir + '\script_base.sql';
            ConfigJsonPath:= AppDir + '\appsettings.json';

            ServidorJson:= NombreServidor;
                StringChange(ServidorJson, '\', '\\');

    // Armado del appsettings.json
    if SoportaTrustServerCertificate() then
    begin
      EscribirLog('Conexión con TrustServerCertificate.');
            JsonContent:= '{ "ConnectionString": "Data Source=' + ServidorJson + ';Initial Catalog=Proyecto_Ing_softw;Integrated Security=True;TrustServerCertificate=True" }';
                end
    else
                    begin
      EscribirLog('Conexión sin TrustServerCertificate.');
            JsonContent:= '{ "ConnectionString": "Data Source=' + ServidorJson + ';Initial Catalog=Proyecto_Ing_softw;Integrated Security=True" }';
                end;

                SaveStringToFile(ConfigJsonPath, JsonContent, False);

                // Ejecutar script_base.sql con PowerShell para no depender obligatoriamente de sqlcmd en la máquina de la facultad
                if FileExists(SqlScriptPath) then
                begin
      EscribirLog('Desplegando base de datos con script_base.sql...');
            PsCommand:= '$conn = New-Object System.Data.SqlClient.SqlConnection(''Server=' + NombreServidor + ';Integrated Security=True''); ' +
                         '$conn.Open(); ' +
                         '$cmd = $conn.CreateCommand(); ' +
                         '$cmd.CommandText = ''IF EXISTS (SELECT name FROM sys.databases WHERE name = N''''Proyecto_Ing_softw'''') BEGIN ALTER DATABASE [Proyecto_Ing_softw] SET SINGLE_USER WITH ROLLBACK IMMEDIATE; DROP DATABASE [Proyecto_Ing_softw]; END''; ' +
                         '$cmd.ExecuteNonQuery(); ' +
                         '$conn.Close();';
                Exec('powershell.exe', '-NoProfile -Command "' + PsCommand + '"', '', SW_HIDE, ewWaitUntilTerminated, ResultCode);

                // Ejecución del archivo script_base.sql
                if Exec(ExpandConstant('{cmd}'), '/c sqlcmd -S "' + NombreServidor + '" -E -i "' + SqlScriptPath + '" -o "' + AppDir + '\Log_SQL.txt"', '', SW_HIDE, ewWaitUntilTerminated, ResultCode) and(ResultCode = 0) then
                begin
        EscribirLog('Base de datos creada exitosamente mediante sqlcmd.');
                end
      else
                    begin
        // Respaldo de ejecución nativa con PowerShell si la PC no tiene sqlcmd
        EscribirLog('Ejecutando script mediante PowerShell (fallback)...');
            PsCommand:= '$script = [System.IO.File]::ReadAllText(''' + SqlScriptPath + '''); ' +
                         '$conn = New-Object System.Data.SqlClient.SqlConnection(''Server=' + NombreServidor + ';Integrated Security=True''); ' +
                         '$conn.Open(); ' +
                         '$batches = $script -split ''(?m)^\s*GO\s*$''; ' +
                         'foreach ($b in $batches) { if ($b.Trim()) { $cmd = $conn.CreateCommand(); $cmd.CommandText = $b; $cmd.ExecuteNonQuery(); } } ' +
                         '$conn.Close();';
                Exec('powershell.exe', '-NoProfile -Command "' + PsCommand + '"', '', SW_HIDE, ewWaitUntilTerminated, ResultCode);
                end;
                end;
                end;
                end;