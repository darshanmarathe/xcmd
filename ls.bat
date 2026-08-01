@echo off
cls
set "TARGET=%cd%"
if "%TARGET:~-1%"=="\" set "TARGET=%TARGET%.

WHERE python
IF %ERRORLEVEL% == 0 python %~dp0list.py "%TARGET%" %* && EXIT /B 2

WHERE scriptcs
IF %ERRORLEVEL% == 0 scriptcs %~dp0list.csx -C -- "%TARGET%" %* && EXIT /B 2

WHERE node
IF %ERRORLEVEL% == 0 node %~dp0list.js "%TARGET%" %* && EXIT /B 2


set BACKDIR=%cd%
