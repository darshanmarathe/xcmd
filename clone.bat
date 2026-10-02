echo %1

@ECHO OFF
set file=%1
FOR %%i IN ("%file%") DO (
  SET foldername=%%~ni
)
echo %foldername%
call git clone %*
cd %foldername%
set BACKDIR=%cd%
call code .
if exist package.json call npm install
if exist yarn.lock call yarn install
if exist pnpm-lock.yaml call pnpm install
if exist go.mod call go build .
if exist requirements.txt call pip install -r .\requirements.txt
if exist Cargo.toml call cargo build
if exist composer.json call composer install
if exist Gemfile call bundle install
if exist *.sln call dotnet restore
if exist *.csproj call dotnet restore
if exist pom.xml call mvn install
if exist build.gradle call gradle build
if exist Makefile call make
