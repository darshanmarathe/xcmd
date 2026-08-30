@echo off
IF [%1]==[] (
    git commit
) ELSE (
    git commit -m %*
)