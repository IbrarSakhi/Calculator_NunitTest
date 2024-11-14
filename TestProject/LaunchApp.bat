@echo off
setlocal

REM Check if running as Administrator
openfiles >nul 2>&1
if %errorlevel% neq 0 (
    echo Restarting script with Administrator privileges...
    powershell -Command "Start-Process '%~f0' -Verb RunAs"
    exit /b
)

REM If the script is running as Admin, execute your command here
echo Running command as administrator...
start "" "J:\SW-E2E\01-ATM Repository\Code Workspace\Working\EMSApplication.exe"

endlocal
