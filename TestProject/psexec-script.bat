@echo off
setlocal

REM Use PsExec to launch application as an admin
PsExec.exe -i 1 -h -d -u POWER\ibrar.sakhi -p Zaroon7890@ "J:\SW-E2E\01-ATM Repository\Code Workspace\Working\EMSApplication.exe"

endlocal