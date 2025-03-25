@echo off
setlocal

REM Use PsExec to launch application as an admin
PsExec.exe -i 1 -s -h -d -u POWER\ibrar.sakhi -p New14266@ "C:\Users\ibrar.sakhi\Desktop\OTA\OTA\bin\Debug\OTA.exe"
endlocal
