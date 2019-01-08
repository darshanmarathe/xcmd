git status 
pause
git merge %1
call vi . 
echo "now finish merge conflicts if any"
pause
git add .
git commit 
git push
