@echo off                
IF [%1]==[-l] (
    call npm install %* --legacy-peer-deps
) ELSE (
    call npm install %*
)