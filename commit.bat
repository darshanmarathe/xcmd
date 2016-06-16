@echo off
git status 
echo Press any key to continue the commit or Ctrl + C to terminate
pause
git add .
IF [%1]==[] (
  git commit
) ELSE (
git commit -m %1
)
status