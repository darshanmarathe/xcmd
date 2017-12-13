@echo off 
echo "Welcome to infoxTech Machine Setup Program"
echo "Installing chocolaty now make sure you are running in admin mode only"
pause
@powershell -NoProfile -ExecutionPolicy Bypass -Command "iex ((new-object net.webclient).DownloadString('https://chocolatey.org/install.ps1'))" && SET PATH=%PATH%;%ALLUSERSPROFILE%\chocolatey\bin
echo "Installed chocolety"
cls 
echo "Testing chocolatey"
choco upgrade all -y
pause
cls
echo "Installing browsers"
choco install googlechrome "%*"
choco install firefox "%*"
choco install opera "%*" 
choco install chromium "%*"
choco install maxthon "%*"


cls 
echo "Installing source control tools"
choco install git "%*"
choco install git.install "%*"
choco install gitextensions "%*"
choco install meld "%*"
choco install tortoisesvn "%*"
choco install sourcetree "%*"
choco install hg "%*"
choco install gitkraken "%*"

cls 

echo "Installing Programing frameworks and languages"
choco install nodejs "%*"
choco install nodejs.install "%*"
choco install javaruntime "%*"
choco install dotnet4.5 "%*"
choco install powershell4 "%*"
choco install ruby "%*"
choco install python "%*"
choco install jdk9 "%*"
choco install golang "%*"
choco install erlang "%*"
choco install dotnetcore-sdk "%*"
choco install elixir "%*"
choco install mono "%*"
choco install rust "%*"
choco install lua "%*"
choco install gtksharp "%*"
choco install julia "%*"

cls
echo "Installing Light weight editors"
choco install notepadplusplus.install "%*"
choco install atom "%*"
choco install sublimetext3 "%*"
choco install visualstudiocode "%*" 
choco install brackets "%*"
choco install vim "%*"
choco install emacs "%*"
choco install markdownpad2 "%*"

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
choco install fiddler4 "%*"
choco install teamviewer "%*"
choco install slack "%*"
choco install camstudio "%*"
choco install putty.install "%*"
choco install gimp "%*"
choco install autohotkey.install "%*"
choco install f.lux "%*"
choco install postman "%*"
choco install httrack "%*"
choco install pencil "%*"

cls 
echo "installing cool utilities"
choco install wget "%*"
choco install curl "%*"
choco install ffmpeg "%*"
choco install scriptcs "%*"


cls
echo "Installing database tools "
choco install mssqlserver2014express "%*"
choco install mssqlservermanagementstudio2014express "%*"
choco install mongodb  "%*"
choco install robomongo "%*"
choco install postgresql "%*"
choco install redis "%*"
choco install neo4j-community "%*"


cls
echo "cloud control"
choco install heroku-cli "%*"
choco install azure-cli "%*"
choco install awscli "%*"


cls 
echo "Installing IDE"
choco install monodevelop "%*"
choco install intellijidea-community "%*"
choco install eclipse  "%*"
choco install netbeans "%*"
choco install liteide "%*"
choco install bluej "%*"
choco install pycharm-community "%*"
choco install visualstudio2017community  "%*"
cls

echo "listing all choco packages"
choco list -lo



cls
echo "Happy coding and best luck."
pause

