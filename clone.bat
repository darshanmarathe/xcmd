echo %1

@ECHO OFF
set file=%1
FOR %%i IN ("%file%") DO (
  SET foldername=%%~ni
)
echo %foldername%
call git clone %*
cd  %foldername%
call vi .
if exist package.json call npm install
if exist go.mod call go build .
