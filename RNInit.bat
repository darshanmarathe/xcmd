call npx react-native@latest init %1
cd %1
pause
call code .
pause
echo  npx react-native start >> RNstart.bat
start npx react-native start
pause 
echo npx react-native run-android >> run.bat
start npx react-native run-android
pause
