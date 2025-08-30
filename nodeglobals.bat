@echo off
cls
call :install  rimraf
call :install  nodemon 
call :install  http-server
call :install  serverless
call :install  @angular/cli 
call :install  create-react-app
call :install  pkg
call :install  node-gyp
call :install  npm-check-updates
call :install  pm2
pause
echo installing the smart AI cli(s)
call :install  @qwen-code/qwen-code@latest
call :install  @google/gemini-cli
call :install  @anthropic-ai/claude-code
:: Function definition
:install
CHOICE /C YN /M "Do you want to install (%~1) globally(Y/N)?"
IF ERRORLEVEL 2 GOTO NO
IF ERRORLEVEL 1 GOTO YES
EXIT /B 0

:YES
echo You chose Yes.
:: Add your commands here
call npm install -g %~1
GOTO END

:NO
echo You chose No.
:: Add your commands here
GOTO END

:END
EXIT /B 0


echo Script finished.
endlocal
EXIT /B 0
