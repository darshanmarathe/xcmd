@echo off

WHERE node
IF ERRORLEVEL 1 (
    Echo node not found. Please install Node.js and try again.
    EXIT /B 1
)

WHERE nodemon
IF ERRORLEVEL 1 (
    Echo nodemon not found. Please install it with: npm install -g nodemon
    EXIT /B 1
)

IF "%~1"=="" (
    echo watch "python main.py" "py"
    EXIT /B 1
)
IF "%~2"=="" (
    echo "watch go run main.go" "go"
    EXIT /B 1
)





echo nodemon --exec %1 -e %2

nodemon --exec %1 -e %2








