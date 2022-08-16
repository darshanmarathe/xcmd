@ECHO OFF

SET /P COLOR="Choose a background color (type red, blue or black): "

2>NUL CALL :CASE_%COLOR% # jump to :CASE_red, :CASE_blue, etc.
IF ERRORLEVEL 1 CALL :DEFAULT_CASE # If label doesn't exist

ECHO Done.
EXIT /B

:CASE_red
  COLOR CF
  GOTO END_CASE
:CASE_blue
  COLOR 9F
  GOTO END_CASE
:CASE_black
  COLOR 0F
  GOTO END_CASE
:DEFAULT_CASE
  ECHO Unknown color "%COLOR%"
  GOTO END_CASE
:END_CASE
  VER > NUL # reset ERRORLEVEL
  GOTO :EOF # return from CALL
Share
Follow
edited Nov 5, 2018 at 21:09
user avatar
Peter Mortensen
30.3k