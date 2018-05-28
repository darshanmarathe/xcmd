@echo off
IF [%2]==[] (
  git clone %1
) ELSE (
  git clone %1 %2
  cd %2  
)


