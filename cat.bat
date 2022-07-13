@echo off

WHERE node
IF %ERRORLEVEL% == 0 node %~dp0cat.js %cd%\%* && EXIT /B 2




WHERE scriptcs
IF %ERRORLEVEL% == 0 scriptcs %~dp0cat.csx -C -- %cd% %* && EXIT /B 2


