@echo off
IF [%1]==[.] (
call start C:\ProgramData\chocolatey\lib\lite-xl\tools\lite-xl\lite-xl.exe %cd%
) ELSE (
call start C:\ProgramData\chocolatey\lib\lite-xl\tools\lite-xl\lite-xl.exe %cd%\%1
)
set BACKDIR=%cd%
