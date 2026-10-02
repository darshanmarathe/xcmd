rem @echo off
call :main %*
exit /b %errorlevel%

:main
set "TARGET=%cd%"
if "%TARGET:~-1%"=="\" set "TARGET=%TARGET%."

WHERE python >NUL 2>NUL
IF %ERRORLEVEL% == 0 (
    python "%~dp0touch.py" "%TARGET%" %*
    IF %ERRORLEVEL% == 0 EXIT /B 0
)

WHERE node >NUL 2>NUL
IF %ERRORLEVEL% == 0 (
    node "%~dp0touch.js" "%TARGET%" %*
    IF %ERRORLEVEL% == 0 EXIT /B 0
)

WHERE scriptcs >NUL 2>NUL
IF %ERRORLEVEL% == 0 (
    scriptcs "%~dp0touch.csx" -C -- "%TARGET%" %*
    IF %ERRORLEVEL% == 0 EXIT /B 0
)

echo Error: No runtime found (python/node/scriptcs)
echo Please install one of them to use the touch command.
EXIT /B 1
