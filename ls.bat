@echo off

WHERE node
IF %ERRORLEVEL% == 0 node %~dp0list.js "%cd%" "%1" && EXIT /B 2


WHERE scriptcs
IF %ERRORLEVEL% == 0 scriptcs %~dp0list.csx -C -- "%cd%" "%1" && EXIT /B 2

set BACKDIR=%cd%
