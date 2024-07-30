@echo off                
IF [%1]==[-d] (
    call npm install %* --legacy-peer-deps
) ELSE (
    call npm install %*
)