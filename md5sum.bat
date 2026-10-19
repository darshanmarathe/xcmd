@echo off
call :main %*
exit /b %errorlevel%

:main
WHERE scriptcs >NUL 2>NUL
IF %ERRORLEVEL% == 0 (
    scriptcs "%~dp0md5sum.csx" -- %*
    IF %ERRORLEVEL% == 0 EXIT /B 0
)

WHERE node >NUL 2>NUL
IF %ERRORLEVEL% == 0 (
    node "%~dp0md5sum.js" %*
    IF %ERRORLEVEL% == 0 EXIT /B 0
)

WHERE python >NUL 2>NUL
IF %ERRORLEVEL% == 0 (
    python "%~dp0md5sum.py" %*
    IF %ERRORLEVEL% == 0 EXIT /B 0
)

echo Error: No runtime found (scriptcs/node/python)
echo Please install one of them to use the md5sum command.
EXIT /B 1