@echo off
if defined BACKDIR (
    cd %BACKDIR%
) else (
    cd ..
)
