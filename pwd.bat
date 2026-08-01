@echo off
set "TARGET=%cd%"
if "%TARGET:~-1%"=="\" set "TARGET=%TARGET%.

WHERE python
IF %ERRORLEVEL% == 0 python %~dp0cwd.py "%TARGET%" "%1" && EXIT /B 2


WHERE node
IF %ERRORLEVEL% == 0 node %~dp0cwd.js "%TARGET%" "%1" && EXIT /B 2


WHERE scriptcs
IF %ERRORLEVEL% == 0 scriptcs %~dp0cwd.csx  -- "%TARGET%" "%1" && EXIT /B 2

set BACKDIR=%cd%
