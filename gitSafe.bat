@echo off
set word=/
set currDir=%cd%
call set currDir=%%currDir:\=%word%%% 
git config --global --add safe.directory %currDir% %*
echo %currDir% added to safe directory list