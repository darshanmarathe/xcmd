del ".UpdateMachine.bat.un~"
del "UpdateMachine.bat~"
choco list 
pause
choco upgrade all
pause
call npm list -g --depth=0
pause
call npm outdated -g --depth=0
pause
call npm update -g