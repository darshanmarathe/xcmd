@echo off

:: Check for scriptcs and run tree.csx if available
WHERE scriptcs >NUL 2>NUL
IF %ERRORLEVEL% == 0 (
    scriptcs "%~dp0tree.csx" -- "%cd%" %*
    EXIT /B %ERRORLEVEL%
)

:: If scriptcs not found, check for node and run tree.js
WHERE node >NUL 2>NUL
IF %ERRORLEVEL% == 0 (
    node "%~dp0tree.js" "%cd%" %*
    EXIT /B %ERRORLEVEL%
)

:: If neither is found
echo.
echo Error: Neither 'scriptcs' nor 'node' was found in your PATH.
echo Please install one of them to use the tree command.
echo.
EXIT /B 1
