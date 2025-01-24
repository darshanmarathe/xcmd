@echo off


WHERE scriptcs
IF %ERRORLEVEL% == 0 scriptcs %~dp0list.csx -C -- "%cd%" %* && EXIT /B 2

EXIT /B

WHERE node
IF %ERRORLEVEL% == 0 node %~dp0list.js "%cd%" %* && EXIT /B 2


set BACKDIR=%cd%
