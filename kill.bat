@echo off


WHERE python
IF %ERRORLEVEL% == 0 python %~dp0kill.py %* && EXIT /B 2

WHERE node
IF %ERRORLEVEL% == 0 node %~dp0kill.js %* && EXIT /B 2

WHERE scriptcs
IF %ERRORLEVEL% == 0 scriptcs %~dp0kill.csx -- %* && EXIT /B 2


`

