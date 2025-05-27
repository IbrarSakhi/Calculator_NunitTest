@echo off
setlocal

REM Use PsExec to launch application as an admin
PsExec -i 1 -h -d -u Power\smartwiresatm -p sw@atm "D:\OTA\OTA\bin\Debug\OTA.exe"

pause

endlocal
