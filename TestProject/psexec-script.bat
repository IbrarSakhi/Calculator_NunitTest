@echo off
setlocal

REM Use PsExec to launch application as an admin
PsExec.exe -i 1 -h -d -u POWER\ibrar.sakhi -p New14266@ "C:\Users\ibrar.sakhi\Desktop\RunTestStandFromJenkin\ConsoleApp1\bin\Debug\ConsoleApp1.exe"
endlocal
