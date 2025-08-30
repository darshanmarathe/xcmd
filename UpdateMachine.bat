del ".UpdateMachine.bat.un~"
del "UpdateMachine.bat~"
cls
del ".install.bat.un~"
del "installe.bat~"
call start %TEMP%
pause
choco list
pause
choco outdated
pause
choco upgrade GoogleChrome
pause
choco upgrade all -v
pause
call npm list -g --depth=0
pause
call npm outdated -g --depth=0
pause
call npm update -g


