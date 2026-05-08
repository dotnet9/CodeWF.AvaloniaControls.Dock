@echo off
dotnet publish -p:PublishProfile=FolderProfile_win-x64.pubxml -f net11.0-windows
explorer "..\..\publish\win-x64"
pause
