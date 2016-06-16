 @echo off                
echo Current Branch Name
echo ===================
IF [%1]==[] (
 git rev-parse --abbrev-ref HEAD
) ELSE (
git branch -%1
)