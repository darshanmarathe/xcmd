@echo off 
echo "Welcome to infoxTech Machine Setup Program"
echo "Installing chocolaty now make sure you are running in admin mode only"
pause
@powershell -NoProfile -ExecutionPolicy Bypass -Command "iex ((new-object net.webclient).DownloadString('https://chocolatey.org/install.ps1'))" && SET PATH=%PATH%;%ALLUSERSPROFILE%\chocolatey\bin
echo "Installed chocolety"
pause
cls
echo "Installing browsers"
choco install googlechrome "%*"
choco install firefox "%*"
choco install opera "%*" 
cls 
echo "Installing source control tools"
choco install git "%*"
choco install git.install "%*"
choco install gitextensions "%*"
choco install meld "%*"
choco install tortoisesvn "%*"
choco install sourcetree "%*"

cls 

echo "Installing Programing frameworks"
choco install nodejs "%*"
choco install nodejs.install "%*"
choco install javaruntime "%*"
choco install dotnet4.5 "%*"
choco install scriptcs "%*"
choco install powershell "%*"
choco install ruby "%*"
choco install python "%*"
choco install wget "%*"


cls
echo "Installing Light weight editors"
 choco install notepadplusplus.install "%*"
 choco install atom "%*"
 choco install sublimetext3 "%*"
 choco install visualstudiocode "%*" 
 choco install brackets "%*"

cls
echo "Installing Important Softwares"
choco install libreoffice "%*"
choco install winmerge"%*"
choco install 7zip "%*"
choco install 7zip.install "%*"
choco install vlc "%*"
choco install skype "%*"
choco install filezilla "%*"
choco install virtualbox "%*"
choco install thunderbird "%*"
choco install fiddler "%*"
choco install teamviewer "%*"
choco install slack "%*"


cls
echo "Installing database tools and a mid level IDE"
choco install mssqlserver2014express "%*"
choco install mssqlservermanagementstudio2014express "%*"
choco install monodevelop "%*"


cls
echo "Now get setup of Visual Studio from some one and install it manually....."
echo "Happy coding and best luck."
pause

