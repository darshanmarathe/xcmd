@echo off
git branch %1
git checkout %1
git push --set-upstream origin %1
