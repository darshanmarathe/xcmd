 @echo off
 IF [%1]==[] (
 git log --graph -10
) ELSE (

 git log --graph -%1

)
