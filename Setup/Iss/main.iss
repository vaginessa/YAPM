; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "Yet Another (remote) Process Monitor"
#define MyAppVer "2.4.0"
#define MyAppPublisher "v_k softwares"
#define MyAppURL "http://yaprocmon.sourceforge.net/"
#define MyAppExeName "YAPM.exe"

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{EFD64A45-12DC-4429-853F-10B453B90F0A}
AppCopyright=Copyright (c) 2009 by violent_ken. Licensed under the GNU GPL, v3.0.
AppContact=maito:alaindescotes@gmail.com
AppName={#MyAppName}
AppVerName={#MyAppName} {#MyAppVer}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={pf}\{#MyAppName}
DefaultGroupName={#MyAppName}
AllowNoIcons=yes
LicenseFile=..\..\YAPM\bin\BuildZipRelease\Bin\license.rtf
InfoBeforeFile=..\..\YAPM\bin\BuildZipRelease\Bin\README.txt
OutputBaseFilename=YAPM-v{#MyAppVer}-Setup
SetupIconFile=..\..\YAPM\process_custom.ico
Compression=lzma/ultra64
SolidCompression=yes
VersionInfoCompany=v_k softwares
VersionInfoCopyright=Licensed under the GNU GPL, v3.0.
VersionInfoProductName=YAPM
OutPutDir=..\..\RELEASE\

[Languages]
Name: english; MessagesFile: compiler:Default.isl

[Tasks]
Name: desktopicon; Description: {cm:CreateDesktopIcon}; GroupDescription: {cm:AdditionalIcons}; Flags: unchecked
Name: quicklaunchicon; Description: {cm:CreateQuickLaunchIcon}; GroupDescription: {cm:AdditionalIcons}; Flags: unchecked
Name: replaceTaskmgr; Description: {cm:ReplaceTaskmgr}; GroupDescription: {cm:OtherTasks}; Check: DoesYAPMReplaceTaskmgr(); Flags: unchecked dontinheritcheck
Name: restoreTaskmgr; Description: {cm:RestoreTaskmgr}; GroupDescription: {cm:OtherTasks}; Check: NOT DoesYAPMReplaceTaskmgr(); Flags: unchecked dontinheritcheck

[Files]
Source: ..\..\YAPM\bin\BuildZipRelease\Bin\changelog.txt; DestDir: {app}; Flags: ignoreversion
Source: ..\..\YAPM\bin\BuildZipRelease\Bin\KernelMemory.sys; DestDir: {app}; Flags: ignoreversion; Check: NOT Is64BitInstallMode()
Source: ..\..\YAPM\bin\BuildZipRelease\Bin\launch server.bat; DestDir: {app}; Flags: ignoreversion
Source: ..\..\YAPM\bin\BuildZipRelease\Bin\license.rtf; DestDir: {app}; Flags: ignoreversion
Source: ..\..\YAPM\bin\BuildZipRelease\Bin\README.txt; DestDir: {app}; Flags: ignoreversion
Source: ..\..\YAPM\bin\BuildZipRelease\Bin\{#MyAppExeName}; DestDir: {app}; Flags: ignoreversion
Source: ..\..\Website\help_static.html; DestDir: {app}\Help\; Flags: ignoreversion
Source: ..\..\Website\styles.css; DestDir: {app}\Help\; Flags: ignoreversion
Source: ..\..\Website\Images\icon.png; DestDir: {app}\Help\Images\; Flags: ignoreversion
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: {group}\{#MyAppName}; Filename: {app}\{#MyAppExeName}
Name: {group}\{cm:ProgramOnTheWeb,{#MyAppName}}; Filename: {#MyAppURL}
Name: {group}\{cm:UninstallProgram,{#MyAppName}}; Filename: {uninstallexe}
Name: {group}\{cm:HelpFile}; Filename: {app}\Help\help_static.html
Name: {commondesktop}\{#MyAppName}; Filename: {app}\{#MyAppExeName}; Tasks: desktopicon
Name: {userappdata}\Microsoft\Internet Explorer\Quick Launch\{#MyAppName}; Filename: {app}\{#MyAppExeName}; Tasks: quicklaunchicon
Name: {group}\{cm:StartServer}; Filename: {app}\launch server.bat; WorkingDir: {app}

[Registry]
Root: HKLM; Subkey: SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\taskmgr.exe; Flags: uninsdeletekeyifempty dontcreatekey
Root: HKLM; Subkey: SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\taskmgr.exe; ValueType: string; ValueName: Debugger; ValueData: """{app}\{#MyAppExeName}"""; Tasks: replaceTaskmgr
Root: HKLM; Subkey: SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\taskmgr.exe; ValueType: string; ValueName: Debugger; ValueData: """{app}\{#MyAppExeName}"""; Flags: uninsdeletevalue; Check: NOT DoesYAPMReplaceTaskmgr()
Root: HKLM; Subkey: SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\taskmgr.exe; ValueName: Debugger; Tasks: restoreTaskmgr; Flags: deletevalue uninsdeletevalue; Check: NOT DoesYAPMReplaceTaskmgr()

[Run]
Filename: {app}\{#MyAppExeName}; Description: {cm:LaunchProgram,{#MyAppName}}; Flags: nowait postinstall skipifsilent
Filename: {win}\Microsoft.NET\Framework\v2.0.50727\ngen.exe; Parameters: "install ""{app}\{#MyAppExeName}"""; StatusMsg: {cm:Optimization}; Flags: runhidden runascurrentuser skipifdoesntexist

[Code]

// YAPM replaces taskmgr ?
function DoesYAPMReplaceTaskmgr(): Boolean;
var
  keyValue: String;
begin
	Result := True;
	if RegQueryStringValue(HKLM, 'SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\taskmgr.exe', 'Debugger', keyValue) then
	begin
		if keyValue = (ExpandConstant('"{app}\{#MyAppExeName}"')) then
		begin
			Result := False;
		end;
	end;
end;

// Initialization of setup
// Check if .Net framework 3.5 is present
function InitializeSetup(): Boolean;
var
	res : Boolean;
	errRes: Integer;
	dotNot3dot5Installed : Boolean;
	winDir : String;
begin
	winDir := GetWinDir();
	dotNot3dot5Installed := DirExists(winDir + '\Microsoft.NET\Framework\v3.5' );
	if dotNot3dot5Installed then
	begin
		Result := True;
	end
	else
	begin
		res := MsgBox(ExpandConstant('{cm:noDotNetInstalled}'), mbCriticalError, MB_YESNO or MB_DEFBUTTON1) = IDYES;
		if res = False then
		begin
			Result := False;
		end
		else
		begin
			Result := False;
			ShellExec('open', 'http://download.microsoft.com/download/7/0/3/703455ee-a747-4cc8-bd3e-98a615c3aedb/dotNetFx35setup.exe', '', '', SW_SHOWNORMAL, ewNoWait, errRes);
		end;
	end;
end;

[CustomMessages]
noDotNetInstalled =YAPM {#MyAppVer} requires Microsoft .Net Framework 3.5 to work. Please install .Net Framework 3.5 and then try to install YAPM again. Would you like to download .Net Framework 3.5 now ?
OtherTasks =Other tasks
RestoreTaskmgr =Restore Windows task manager
ReplaceTaskmgr =Replace Windows task manager
Optimization =Optimizing Yet Another (remote) Process Monitor...
StartServer=Start YAPM server
HelpFile=Help
