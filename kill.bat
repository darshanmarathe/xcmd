@echo off

WHERE node
IF %ERRORLEVEL% == 0 node %~dp0kill.js %* && EXIT /B 2

WHERE scriptcs
IF %ERRORLEVEL% == 0 scriptcs %~dp0kill.csx -- %* && EXIT /B 2




