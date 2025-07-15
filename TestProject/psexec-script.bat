@echo off
setlocal

REM Use PsExec to launch application as an admin
PsExec.exe -i  1 -h -d -u POWER\ibrar.sakhi -p YaHussain2@ "J:\SW-Swift\01-ATM Repository\Code Workspace\Working\SWIFTATMTestApplication.exe"

endlocal
