@echo off
cd /d "%~1" 2>nul || cd /d "%cd%"
ll %*
set BACKDIR=%cd%