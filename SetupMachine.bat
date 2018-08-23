@echo off 
echo "Welcome to infoxTech Machine Setup Program"
echo "Installing chocolaty now make sure you are running in admin mode only"
pause
rem @powershell -NoProfile -ExecutionPolicy Bypass -Command "iex ((new-object net.webclient).DownloadString('https://chocolatey.org/install.ps1'))" && SET PATH=%PATH%;%ALLUSERSPROFILE%\chocolatey\bin
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
choco install android-sdk "%*"
choco install electron "%*"

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
choco install libreoffice "%*"
choco install winmerge"%*"
choco install 7zip "%*"
choco install 7zip.install "%*"
choco install vlc "%*"
choco install skype "%*"
choco install filezilla "%*"
choco install virtualbox "%*"
choco install thunderbird "%*"
choco install wireshark "%*"
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
choco install evernote  "%*"
choco install sysinternals "%*"
choco install dropbox "%*"  
choco install httrack.app "%*"
choco install microsoft-teams "%*"
choco install office365business
choco install anydesk "%*"
choco install projectlibre "%*" 
choco install wps-office-free "%*"



cls 
echo "installing cool utilities"
choco install wget "%*"
choco install curl "%*"
choco install ffmpeg "%*"
choco install scriptcs "%*"
choco install openssl.light "%*" 
choco install opencv "%*"
choco install prefix "%*"
choco install whois  "%*"

cls
echo "Installing database tools "
choco install sql-server-expresss "%*"
choco install sql-server-management-studio "%*"
choco install mongodb  "%*"
choco install robomongo "%*"
choco install postgresql "%*"
choco install redis "%*"
choco install neo4j-community "%*"
choco install solr "%*"
choco install dbmigration "%*"

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

