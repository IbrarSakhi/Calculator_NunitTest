@echo off
setlocal

REM Use PsExec to launch application as an admin
PsExec.exe -i 1 -h -d -u POWER\smartwiresatm -p sw@atm "J:\SW-E2E\01-ATM Repository\Code Workspace\Working\RunTestStandsSeq.exe"
endlocal
