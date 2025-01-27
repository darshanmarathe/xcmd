
@echo off         
IF [%1]==[] (
 go build . %*
)ELSE (
 go build %*
)