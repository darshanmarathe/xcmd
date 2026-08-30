@echo off
call :main %*
exit /b %errorlevel%

:main
set "TARGET=%cd%"
if "%TARGET:~-1%"=="\" set "TARGET=%TARGET%."

:: Check for scriptcs and run tree.csx if available
WHERE scriptcs >NUL 2>NUL
IF %ERRORLEVEL% == 0 (
    scriptcs "%~dp0tree.csx" -- "%TARGET%" %*
    EXIT /B %ERRORLEVEL%
)

:: If scriptcs not found, check for node and run tree.js
WHERE node >NUL 2>NUL
IF %ERRORLEVEL% == 0 (
    node "%~dp0tree.js" "%TARGET%" %*
    EXIT /B %ERRORLEVEL%
)

:: If python found, run tree.py
WHERE python >NUL 2>NUL
IF %ERRORLEVEL% == 0 (
    python "%~dp0tree.py" "%TARGET%" %*
    EXIT /B %ERRORLEVEL%
)

:: If neither is found
echo.
echo Error: Neither 'scriptcs' nor 'node' nor 'python' was found in your PATH.
echo Please install one of them to use the tree command.
echo.
EXIT /B 1