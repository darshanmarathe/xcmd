@Echo delete branch locally
git branch -D %1
pause
@Echo delete branch remotely
git push origin --delete %1