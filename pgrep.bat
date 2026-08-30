@echo off
call :main %*
exit /b %errorlevel%

:main
WHERE python >NUL 2>NUL
IF %ERRORLEVEL% == 0 (
    python "%~dp0pgrep.py" %*
    IF %ERRORLEVEL% == 0 EXIT /B 0
)

WHERE node >NUL 2>NUL
IF %ERRORLEVEL% == 0 (
    node "%~dp0pgrep.js" %*
    IF %ERRORLEVEL% == 0 EXIT /B 0
)

WHERE scriptcs >NUL 2>NUL
IF %ERRORLEVEL% == 0 (
    scriptcs "%~dp0pgrep.csx" -- %*
    IF %ERRORLEVEL% == 0 EXIT /B 0
)

echo Error: No runtime found (python/node/scriptcs)
echo Please install one of them to use the pgrep command.
EXIT /B 1