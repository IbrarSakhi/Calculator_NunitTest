@echo off
setlocal

REM Use PsExec to launch application as an admin
psexec -i -d "D:\OTA\OTA\bin\Debug\OTA.exe"


endlocal
