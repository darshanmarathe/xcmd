@echo off
echo Current Branch Name
echo ===================
IF [%1]==[] (
    git rev-parse --abbrev-ref HEAD
) ELSE IF /i "%1"=="a" (
    git branch -a
) ELSE (
    git branch %*
)