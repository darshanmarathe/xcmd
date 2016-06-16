@echo off

git status 
REM Press any key to continue the commit or Ctrl + C to terminate
pause
git add .
IF [%1]==[] (
  git commit
) ELSE (
git commit -m %1
)
git push 
echo Done Check-In and Pushed to server 
pause
status