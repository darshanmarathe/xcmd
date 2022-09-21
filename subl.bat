@echo off
IF [%1]==[.] (
call "C:\Program Files\Sublime Text\subl.exe" %cd%
) ELSE (
call "C:\Program Files\Sublime Text\subl.exe" %cd%\%1
)
