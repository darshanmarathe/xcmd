@echo off


WHERE node
IF %ERRORLEVEL% == 0 node %~dp0dp0touch.js %* %cd% && EXIT /B 2



WHERE scriptcs
IF %ERRORLEVEL% == 0 scriptcs %~dp0touch.csx -C -- %* %cd% && EXIT /B 2



