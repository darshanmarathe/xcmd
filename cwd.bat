@echo off
WHERE python
IF %ERRORLEVEL% == 0 python %~dp0cwd.py "%cd%" "%1" && EXIT /B 2


WHERE node
IF %ERRORLEVEL% == 0 node %~dp0cwd.js "%cd%" "%1" && EXIT /B 2


WHERE scriptcs
IF %ERRORLEVEL% == 0 scriptcs %~dp0cwd.csx  -- "%cd%" "%1" && EXIT /B 2

set BACKDIR=%cd%
