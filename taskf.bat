@echo off
if [%1]==[] (
    echo Usage: taskf ^<process_name^>
    echo Example: taskf node
    exit /b 1
)
tasklist | findstr /i "%*"
