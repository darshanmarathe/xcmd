@echo off
IF [%1]==[.] (
call %UserProfile%\AppData\Local\atom\atom.exe %cd%
) ELSE (
call %UserProfile%\AppData\Local\atom\atom.exe %cd%\%1
)
set BACKDIR=%cd%
