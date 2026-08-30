@echo off
call :main %*
exit /b %errorlevel%

:main
title XCMD - %~nx0
cls
set "TARGET=%cd%"
if "%TARGET:~-1%"=="\" set "TARGET=%TARGET%."

WHERE python >NUL 2>NUL
IF %ERRORLEVEL% == 0 (
    python "%~dp0list.py" "%TARGET%" %*
    exit /b %errorlevel%
)

WHERE node >NUL 2>NUL
IF %ERRORLEVEL% == 0 (
    node "%~dp0list.js" "%TARGET%" %*
    exit /b %errorlevel%
)

WHERE scriptcs >NUL 2>NUL
IF %ERRORLEVEL% == 0 (
    scriptcs "%~dp0list.csx" -- "%TARGET%" %*
    exit /b %errorlevel%
)

echo Error: No runtime found (python/node/scriptcs)
echo Please install one of them to use the ls command.
exit /b 1