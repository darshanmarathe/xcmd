rem @echo off
call :main %*
exit /b %errorlevel%

:main
set "TARGET=%cd%"
if "%TARGET:~-1%"=="\" set "TARGET=%TARGET%."

@REM  WHERE python >NUL 2>NUL
@REM  IF %ERRORLEVEL% == 0 (
@REM      python "%~dp0touch.py" "%TARGET%" %*
@REM      IF %ERRORLEVEL% == 0 EXIT /B 0
@REM  )

@REM  WHERE node >NUL 2>NUL
@REM  IF %ERRORLEVEL% == 0 (
@REM      node "%~dp0touch.js" "%TARGET%" %*
@REM      IF %ERRORLEVEL% == 0 EXIT /B 0
@REM  )

WHERE scriptcs >NUL 2>NUL
IF %ERRORLEVEL% == 0 (
    scriptcs "%~dp0touch.csx" -C -- "%TARGET%" %*
    IF %ERRORLEVEL% == 0 EXIT /B 0
)

echo Error: No runtime found (python/node/scriptcs)
echo Please install one of them to use the touch command.
EXIT /B 1
