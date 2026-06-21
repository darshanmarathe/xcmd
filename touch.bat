@echo off



WHERE python
IF %ERRORLEVEL% == 0 python %~dp0touch.py %* && EXIT /B 2



WHERE node
IF %ERRORLEVEL% == 0 node %~dp0touch.js %* && EXIT /B 2



WHERE scriptcs
IF %ERRORLEVEL% == 0 scriptcs %~dp0touch.csx -C -- %* && EXIT /B 2
