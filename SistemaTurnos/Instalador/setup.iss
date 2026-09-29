; Configuración principal del instalador
#define MyAppName "Sistema de Guardia Clínica"
#define MyAppVersion "1.0.0"
#define MyAppExeName "SistemaTurnos.exe" ; 

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

[Files]
; 1. Copia todos los binarios desde la carpeta bin\Release que está un nivel arriba
Source: "..\bin\Release\{#MyAppExeName}"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\bin\Release\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs

; 2. Copia obligatoriamente el script de la base de datos (que debe estar junto al .iss en la carpeta Instalador)
Source: "..\..\DAL\script_base.sql"; DestDir: "{app}"; Flags: ignoreversion


[Icons]
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"

[Run]
; Levanta la aplicación automáticamente al terminar la instalación
Filename: "{app}\{#MyAppExeName}"; Description: "Ejecutar la aplicación ahora"; Flags: nowait postinstall skipifsilent

[Code]
function InitializeSetup(): Boolean;
var
  ResultCode: Integer;
begin
  Result := True;
  
  // 1. Intenta encender SQLEXPRESS (Típico de la facultad)
  Exec('net', 'start MSSQL$SQLEXPRESS', '', SW_HIDE, ewWaitUntilTerminated, ResultCode);
  
  // 2. Intenta encender la instancia por defecto (Por si en tu casa tenés el SQL normal)
  Exec('net', 'start MSSQLSERVER', '', SW_HIDE, ewWaitUntilTerminated, ResultCode);
end;

procedure CurStepChanged(CurStep: TSetupStep);
var
  ResultCode: Integer;
  AppDir: String;
  SqlScriptPath: String;
begin
  if CurStep = ssPostInstall then
  begin
    AppDir := ExpandConstant('{app}');
    SqlScriptPath := AppDir + '\script_base.sql';

    // 2. Si la base de datos existe, la DROPEA (cierra conexiones activas primero para que no falle)
    Exec('sqlcmd', '-S .\SQLEXPRESS -E -Q "IF EXISTS (SELECT name FROM sys.databases WHERE name = N''Proyecto_Ing_softw'') BEGIN ALTER DATABASE [Proyecto_Ing_softw] SET SINGLE_USER WITH ROLLBACK IMMEDIATE; DROP DATABASE [Proyecto_Ing_softw]; END"', '', SW_HIDE, ewWaitUntilTerminated, ResultCode);

    // 3. Ejecuta tu script completo (que ya tiene el CREATE DATABASE adentro)
    if FileExists(SqlScriptPath) then
    begin
      Exec('sqlcmd', '-S .\SQLEXPRESS -E -i "' + SqlScriptPath + '"', '', SW_HIDE, ewWaitUntilTerminated, ResultCode);
    end;
  end;
end;