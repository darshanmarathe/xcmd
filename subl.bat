@echo off
IF [%1]==[.] (
call "C:\Program Files\Sublime Text 3\subl.exe" %cd%
) ELSE (
call "C:\Program Files\Sublime Text 3\subl.exe" %cd%\%1
)
