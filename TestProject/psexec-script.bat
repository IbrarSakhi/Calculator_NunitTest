@echo off
setlocal

REM Use PsExec to launch application as an admin
PsExec.exe -i -d "C:\Users\smartwiresatm\Desktop\OTA\OTA\bin\Debug\OTA.exe"

endlocal
