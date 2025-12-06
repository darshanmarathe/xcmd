@echo off
setlocal enabledelayedexpansion

REM XCMD - bash++ utility dispatcher
REM Accepts multiple arguments to show help or describe commands

if [%1]==[] (
    call :showHelp
    exit /b 0
)

if /i "%1"=="help" (
    call :showHelp
    exit /b 0
)

if /i "%1"=="-?" (
    call :showHelp
    exit /b 0
)

if /i "%1"=="-h" (
    call :showHelp
    exit /b 0
)

REM Process each argument passed
:processArgs
if [%1]==[] exit /b 0

set "cmd=%1"

if /i "%cmd%"=="npi" (
    echo npi -> npm install 
    echo npi <packages> -> npm install <packages> 
    echo npi -l <packages> -> npm install <packages> with legacy peer deps
    shift
    goto processArgs
)

if /i "%cmd%"=="npr" (
    echo npr -> "npm start"
    echo npm run  <script> -> execute npm scripts from package.json
    shift
    goto processArgs
)

if /i "%cmd%"=="npu" (
    echo npu -> npm uninstall - removes packages and updates package.json
    shift
    goto processArgs
)

if /i "%cmd%"=="npg" (
    echo npg <package/packages> -> npm global packages management
    shift
    goto processArgs
)

if /i "%cmd%"=="cat" (
    echo display file contents with optional line numbers and clipboard copy
    shift
    goto processArgs
)

if /i "%cmd%"=="ls" (
    echo list directory contents in a bash-like format
    shift
    goto processArgs
)

if /i "%cmd%"=="clone" (
    echo clone repository, auto-install dependencies, and open in VS Code
    shift
    goto processArgs
)

if /i "%cmd%"=="branch" (
    echo show current git branch or list all branches with 'a' flag
    shift
    goto processArgs
)

if /i "%cmd%"=="push" (
    echo push changes to remote git repository
    shift
    goto processArgs
)

if /i "%cmd%"=="pull" (
    echo pull changes from remote git repository
    shift
    goto processArgs
)

if /i "%cmd%"=="commit" (
    echo create git commit with message
    shift
    goto processArgs
)

if /i "%cmd%"=="merge" (
    echo merge git branches
    shift
    goto processArgs
)

if /i "%cmd%"=="kill" (
    echo terminate running processes by name
    shift
    goto processArgs
)

if /i "%cmd%"=="zip" (
    echo compress folder using 7zip
    shift
    goto processArgs
)

if /i "%cmd%"=="unzip" (
    echo extract compressed files
    shift
    goto processArgs
)

if /i "%cmd%"=="serv" (
    echo start HTTP server in current or specified directory
    shift
    goto processArgs
)

if /i "%cmd%"=="watch" (
    echo monitor files and auto-run commands on changes using nodemon
    shift
    goto processArgs
)

if /i "%cmd%"=="touch" (
    echo create empty file or update timestamp
    shift
    goto processArgs
)

if /i "%cmd%"=="tree" (
    echo display directory structure in tree format
    shift
    goto processArgs
)

if /i "%cmd%"=="diff" (
    echo show git differences between commits or branches
    shift
    goto processArgs
)

if /i "%cmd%"=="log" (
    echo display git commit history
    shift
    goto processArgs
)

if /i "%cmd%"=="status" (
    echo show git status and uncommitted changes
    shift
    goto processArgs
)

if /i "%cmd%"=="addtopath" (
    echo add current directory to system PATH variable
    shift
    goto processArgs
)

if /i "%cmd%"=="setupmachine" (
    echo complete machine setup - installs chocolatey, git, nvm, node, browsers, dev tools
    shift
    goto processArgs
)

if /i "%cmd%"=="nodeglobals" (
    echo install global npm packages for development
    shift
    goto processArgs
)

echo Unknown command: %cmd%
shift
goto processArgs

exit /b 0

:showHelp
echo.
echo ============================================
echo         XCMD - Bash++ for Windows
echo ============================================
echo.
echo Usage: xcmd [command] [command] ...
echo.
echo Examples:
echo   xcmd help              - show this help
echo   xcmd npi               - see what npi does
echo   xcmd clone push        - get info on clone and push
echo   xcmd -?                - show this help
echo.
echo Common Commands:
echo   PACKAGE MANAGERS:  npi, npr, npu
echo   FILE UTILS:        cat, ls, touch, tree, zip, unzip
echo   GIT:               clone, branch, push, pull, commit, merge, diff, log, status
echo   PROCESS:           kill, watch
echo   SYSTEM:            serv, addtopath, setupmachine, nodeglobals
echo.
echo Type: xcmd [command] to see what each command does
echo.
exit /b 0
