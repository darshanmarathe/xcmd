echo %1

@ECHO OFF
SETLOCAL
set file=%1
FOR %%i IN ("%file%") DO (
  SET foldername=%%~ni
)
echo %foldername%
call git clone %1
cd %foldername%
vi .
cd %foldername%
