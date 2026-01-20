echo %1

@ECHO OFF
set file=%1
FOR %%i IN ("%file%") DO (
  SET foldername=%%~ni
)
echo %foldername%
call git clone %*
cd  %foldername%
set BACKDIR=%cd%
call vi .
if exist package.json call npm install
if exist go.mod call go build .
if exist requirements.txt call pip install -r .\requirements.txt
if exist  Cargo.toml call cargo build
