
@echo off         
IF [%1]==[] (
 go run . %*
)ELSE (
 go run %* 
)