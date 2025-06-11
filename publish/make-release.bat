@echo off

cd /d %~dp0

xcopy ..\src\RemoteConnectionManager.Rdp\bin\Release\*.* .\Application-Files\ /Y
xcopy ..\src\RemoteConnectionManager.ExternalProcess\bin\Release\*.* .\Application-Files\ /Y
xcopy ..\src\RemoteConnectionManager.Core\bin\Release\*.* .\Application-Files\ /Y
xcopy ..\src\RemoteConnectionManager\bin\Release\*.* .\Application-Files\ /Y
xcopy ..\dist\*.* .\Application-Files\dist\ /Y

:createZipArchive
if exist .\rcman-release.zip del .\rcman-release.zip
"%ProgramFiles%\7-Zip\7z.exe" a -t7z -mx9 -r .\rcman-release.zip .\Application-Files\*.*

:createSetup
"%ProgramFiles(x86)%\Inno Setup 6\ISCC.exe" %~dp0setup.iss
