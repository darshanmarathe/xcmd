
@echo off                
echo Running IIS with ngRok
WHERE ngrok
IF %ERRORLEVEL% NEQ 0 echo "install ngRok and try again" && exit
echo ===================
IF [%1]==[] (
 ngrok http -host-header=localhost 8080
) ELSE (
 ngrok http -host-header=localhost %1
)

