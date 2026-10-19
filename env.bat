@echo off
call :main %*
exit /b %errorlevel%

:main
WHERE scriptcs >NUL 2>NUL
IF %ERRORLEVEL% == 0 (
    scriptcs "%~dp0env.csx" -- %*
    IF %ERRORLEVEL% == 0 EXIT /B 0
)

WHERE node >NUL 2>NUL
IF %ERRORLEVEL% == 0 (
    node "%~dp0env.js" %*
    IF %ERRORLEVEL% == 0 EXIT /B 0
)

WHERE python >NUL 2>NUL
IF %ERRORLEVEL% == 0 (
    python "%~dp0env.py" %*
    IF %ERRORLEVEL% == 0 EXIT /B 0
)

echo Error: No runtime found (scriptcs/node/python)
echo Please install one of them to use the env command.
EXIT /B 1