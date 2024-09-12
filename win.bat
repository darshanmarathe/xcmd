@echo off
IF [%1]==[] (
 start .
) ELSE (
 start %1
)
set BACKDIR=%cd%
