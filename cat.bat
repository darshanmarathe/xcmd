@echo off
call :main %*
exit /b %errorlevel%

:main
WHERE python >NUL 2>NUL
IF %ERRORLEVEL% == 0 (
    python "%~dp0cat.py" %*
    IF %ERRORLEVEL% == 0 EXIT /B 0
)

WHERE node >NUL 2>NUL
IF %ERRORLEVEL% == 0 (
    node "%~dp0cat.js" %*
    IF %ERRORLEVEL% == 0 EXIT /B 0
)

WHERE scriptcs >NUL 2>NUL
IF %ERRORLEVEL% == 0 (
    scriptcs "%~dp0cat.csx" -C -- %*
    IF %ERRORLEVEL% == 0 EXIT /B 0
)

echo Error: No runtime found (python/node/scriptcs)
echo Please install one of them to use the cat command.
EXIT /B 1