@echo off
WHERE http-server
IF %ERRORLEVEL% == 0 http-server %1 -c-1 -o

IF %ERRORLEVEL% NOT 0
set BACKDIR=%cd%
