 @echo off
 IF [%1]==[] (
 git log -10
) ELSE (

 git log -%1

)