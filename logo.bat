 @echo off
 IF [%1]==[] (
 git log --graph --oneline -10
) ELSE (

 git log --graph --oneline -%1

)
