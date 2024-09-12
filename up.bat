@echo off
set BACKDIR=%cd%
IF [%1]==[] (
  cd ..
  EXIT /B
)

IF %1%==\ (
 cd \
) ELSE (
  for /l %%x in (1, 1, %1) do (
  cd ..
  )
)
