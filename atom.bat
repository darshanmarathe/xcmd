@echo off                
IF [%1]==[.] (
call C:\Users\darsh\AppData\Local\atom\atom.exe %cd%
) ELSE (
call C:\Users\darsh\AppData\Local\atom\atom.exe %cd%\%1
)