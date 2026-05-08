@echo off
dotnet publish -p:PublishProfile=FolderProfile_linux-x64.pubxml -f net11.0
explorer "..\..\publish\linux-x64"
pause
