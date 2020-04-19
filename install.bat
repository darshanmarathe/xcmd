@echo off 
echo "Welcome to infoxTech Machine Setup Program"
echo "Installing chocolaty now make sure you are running in admin mode only"
pause
WHERE choco
IF %ERRORLEVEL% NEQ 0 @powershell -NoProfile -ExecutionPolicy Bypass -Command "iex ((new-object net.webclient).DownloadString('https://chocolatey.org/install.ps1'))" && SET PATH=%PATH%;%ALLUSERSPROFILE%\chocolatey\bin 
echo "Installed chocolety"
cls 
echo "Testing chocolatey"
choco install chocolatey-core.extension -y
choco list -lo
choco upgrade all -y
pause
cls
echo "Installing browsers"
choco install googlechrome "%*"
choco install firefox "%*"
choco install opera "%*" 
choco install chromium "%*"
choco install maxthon "%*"
choco install midori-browser "%*"
choco install vivaldi "%*"
choco install brave "%*"



cls 
echo "Installing source control tools"
choco install git "%*"
choco install git.install "%*"
choco install gitextensions "%*"
choco install git-credential-manager-for-windows "%*"
choco install git-lfs.install "%*"
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
choco install jdk8 "%*"
choco install golang "%*"
choco install erlang "%*"
choco install dotnetcore-sdk "%*"
choco install elixir "%*"
choco install mono "%*"
choco install rust "%*"
choco install lua "%*"
choco install gtksharp "%*"
choco install julia "%*"
choco install android-sdk "%*"
choco install electron "%*"
choco install scriptcs "%*"
choco install silverlight "%*" 
choco install groovy

cls
echo "Installing Light weight editors"
choco install sourcecodepro  "%*"
choco install notepadplusplus.install "%*"
choco install atom "%*"
choco install sublimetext3 "%*"
choco install visualstudiocode "%*" 
choco install brackets "%*"
choco install vim "%*"
choco install emacs "%*"
choco install micro
choco install markdownpad2 "%*"
choco install scite "%*"


cls
echo "Installing Important Softwares and office utilities"
choco install autohotkey.install "%*"
choco install grammarly "%*"
choco install winmerge"%*"
choco install 7zip "%*"
choco install 7zip.install "%*"
choco install vlc "%*"
choco install filezilla "%*"
choco install virtualbox "%*"
choco install wireshark "%*"
choco install camstudio "%*"
choco install putty.install "%*"
choco install f.lux "%*"
choco install postman "%*"
choco install httrack "%*"
choco install httrack.app "%*"
choco install dropbox "%*"
choco install megasync "%*"  
choco install pencil "%*"
choco install evernote  "%*"
choco install sysinternals "%*"
choco install skype "%*"
choco install slack "%*"
choco install microsoft-teams "%*"
choco install office365business
choco install libreoffice "%*"
choco install wps-office-free "%*"
choco install thunderbird "%*"
choco install projectlibre "%*" 
choco install gimp "%*"
choco install mobaxterm "%*"
choco install teamviewer "%*"
choco install anydesk "%*"
choco install zoom "%*"
choco install ccleaner "%*"
choco install microsoft-windows-terminal  "%*"

cls 
echo "installing cool utilities"
choco install wget "%*"
choco install curl "%*"
choco install ffmpeg "%*"
choco install whois  "%*"
choco install cmder "%*"
choco install openssl.light "%*" 
choco install opencv "%*"
choco install prefix "%*"
choco install dotpeek "%*"

cls
echo "Installing database tools "
choco install sql-server-express "%*"
choco install sql-server-management-studio "%*"
choco install mongodb  "%*"
choco install robomongo "%*"
choco install postgresql "%*"
choco install redis "%*"
choco install neo4j-community "%*"
choco install solr "%*"


cls
echo "Docker stuff"
choco install docker-desktop 
choco install minikube

cls
echo "cloud control"
choco install heroku-cli "%*"
choco install azure-cli "%*"
choco install awscli "%*"
choco install carina "%*"
choco install cloudfoundry-cli "%*"


cls 
echo "Installing IDEs"
choco install monodevelop "%*"
choco install sharpdevelop "%*"
choco install intellijidea-community "%*"
choco install androidstudio  "%*"
choco install eclipse  "%*"
choco install netbeans "%*"
choco install liteide "%*"
choco install bluej "%*"
choco install pycharm-community "%*"
choco install visualstudio2017community  "%*"
choco install visualstudio2019community
choco install r.studio "%*"
choco install kdevelop "%*"
cls

echo "Other Server products"
choco install jenkins  "%*"
choco install rabbitmq "%*"
choco install nginx "%*"
choco install apache-httpd "%*"

echo "Installing Antivirus"
choco install avgantivirusfree "%*"
cls

echo "listing all choco packages"
choco list -lo
pause


cls
echo "Happy coding and best luck."
pause
