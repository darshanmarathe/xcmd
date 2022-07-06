@echo off

WHERE nodes
IF %ERRORLEVEL% == 0 goto :npmInst

:npmInst
set "reply=y"
set /p "reply=Install Npm global Packages [y|n]: "
if /i "%reply%" == "y" call nodeglobals.bat

