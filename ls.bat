@echo off
cls
WHERE python
IF %ERRORLEVEL% == 0 python %~dp0list.py "%cd%" %* && EXIT /B 2

WHERE scriptcs
IF %ERRORLEVEL% == 0 scriptcs %~dp0list.csx -C -- "%cd%" %* && EXIT /B 2

WHERE node
IF %ERRORLEVEL% == 0 node %~dp0list.js "%cd%" %* && EXIT /B 2


set BACKDIR=%cd%
