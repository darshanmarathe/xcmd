Set "currentPath=%cd%"
set "currentDrive=%cd:~0,2%"
echo %currentDrive%
C:
cd "C:\Program Files (x86)\Jenkins"
start java -jar jenkins.war --httpPort=9001
start ngrok http 9001
%currentDrive%
cd %currentPath%
