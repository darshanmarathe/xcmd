@echo off


WHERE node
IF %ERRORLEVEL% == 0 node %~dp0touch.js %* %cd% && EXIT /B 2



@REM WHERE scriptcs
@REM IF %ERRORLEVEL% == 0 scriptcs %~dp0touch.csx -C -- %* %cd% && EXIT /B 2



