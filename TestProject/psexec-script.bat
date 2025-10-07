@echo off
setlocal

REM Use PsExec to launch application as an admin
PsExec.exe -i  1 -h -d -u POWER\smartwiresatm -p sw@atm "C:\Users\smartwiresatm\Desktop\OTA\OTA\OTA\OTA\bin\Debug\OTA.exe"

endlocal
