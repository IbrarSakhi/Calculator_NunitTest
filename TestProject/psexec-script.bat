@echo off
setlocal

PsExec -i 1 -h -d -u Power\smartwiresatm -p sw@atm "D:\OTA\OTA\bin\Debug\OTA.exe"

endlocal
