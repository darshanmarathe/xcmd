@echo off 
echo "Welcome to infoxTech Machine Setup Program"
echo "Installing chocolaty now make sure you are running in admin mode only"
pause
@powershell -NoProfile -ExecutionPolicy Bypass -Command "iex ((new-object net.webclient).DownloadString('https://chocolatey.org/install.ps1'))" && SET PATH=%PATH%;%ALLUSERSPROFILE%\chocolatey\bin
echo "Installed chocolety"
pause
cls
echo "Installing browsers"
choco install googlechrome -y
choco install firefox -y
choco install opera -y 
cls 
echo "Installing source control tools"
choco install git -y
choco install git.install -y
choco install gitextensions -y
choco install meld -y
choco install tortoisesvn -y
choco install sourcetree -y

cls 

echo "Installing Programing frameworks"
choco install nodejs -y
choco install nodejs.install -y
choco install javaruntime -y
choco install dotnet4.5 -y
choco install scriptcs -y
choco install powershell -y
choco install ruby -y
choco install python -y
choco install wget -y


cls
echo "Installing Light weight editors"
 choco install notepadplusplus.install -y
 choco install atom -y
 choco install sublimetext3 -y
 choco install visualstudiocode -y 
 choco install brackets -y

cls
echo "Installing Important Softwares"
choco install libreoffice -y
choco install winmerge-y
choco install 7zip -y
choco install 7zip.install -y
choco install vlc -y
choco install skype -y
choco install filezilla -y
choco install virtualbox -y
choco install thunderbird -y
choco install fiddler -y
choco install teamviewer -y
choco install slack -y


cls
echo "Installing database tools and a mid level IDE"
choco install mssqlserver2014express -y
choco install mssqlservermanagementstudio2014express -y
choco install monodevelop


cls
echo "Now get setup of Visual Studio from some one and install it manually....."
echo "Happy coding and best luck."
pause

