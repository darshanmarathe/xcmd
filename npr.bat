
@echo off         
IF [%1]==[] (
 npm run start
)ELSE (
 npm run -%1
)