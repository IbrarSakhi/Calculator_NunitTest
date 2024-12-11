@echo off
setlocal

REM Use PsExec to launch application as an admin
PsExec.exe -i 1 -h -d -u POWER\ibrar.sakhi -p Zaroon7890@ "C:\Program Files\National Instruments\TestStand 2016\UserInterfaces\Full-Featured\CSharp\Source Code\Bin\x64\release\TestExec.exe" -run MainSequence "J:\SW-E2E\01-ATM Repository\Scripts Workspace\Scripts\01 Core APIs Scripts\OpenSmartInterface.seq"

endlocal
