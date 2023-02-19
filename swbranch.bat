@echo off
git fetch
git checkout %1
git pull origin %1
call branch
