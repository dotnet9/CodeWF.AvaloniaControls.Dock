@echo off
dotnet publish -p:PublishProfile=FolderProfile_linux-x64.pubxml -f net11.0
if errorlevel 1 exit /b 1
for /r "%~dp0..\..\artifacts\publish" %%f in (*.pdb) do del /q "%%f" 2>nul
explorer "%~dp0..\..\artifacts\publish"
pause
