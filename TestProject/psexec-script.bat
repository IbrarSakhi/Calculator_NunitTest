@echo off
setlocal

REM Use PsExec to launch application as an admin
PsExec.exe -i  1 -h -d -u POWER\ibrar.sakhi -p YaHussain2@ "C:\Users\smartwiresatm\Desktop\SWIFT\Code Workspace\Working\SWIFTATMTestApplication.exe"

endlocal
