@echo off

WHERE node 
IF %ERRORLEVEL% == 0 node %~dp0pwd.js "%cd%" "%1" && EXIT /B 2


WHERE scriptcs 
IF %ERRORLEVEL% == 0 scriptcs %~dp0pwd.csx  -- "%cd%" "%1" && EXIT /B 2


