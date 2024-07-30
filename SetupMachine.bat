@echo off
echo "Welcome to infoxTech Machine Setup Program"
echo "Installing chocolaty now make sure you are running in admin mode only"
pause
WHERE choco
IF %ERRORLEVEL% NEQ 0 @powershell -NoProfile -ExecutionPolicy Bypass -Command "iex ((new-object net.webclient).DownloadString('https://chocolatey.org/install.ps1'))" && SET PATH=%PATH%;%ALLUSERSPROFILE%\chocolatey\bin
call refreshenv
echo "Installed chocolety"
cls
echo "Testing chocolatey"
choco install chocolatey-core.extension -y
choco list 
choco upgrade all %*
pause
cls
echo "Installing essentials"
choco install git "%*"
choco install git.install "%*"
choco install lite-xl "%*"
choco install cmder "%*"
choco install nvm "%*"
call refreshenv
call nvm install lts
call nvm use lts
choco install javaruntime "%*"
choco install netfx-4.8 "%*"
choco install scriptcs "%*"
choco install notepadplusplus.install "%*"
choco install googlechrome "%*"
pause
WHERE node
IF %ERRORLEVEL% == 0 call nodeglobals.bat

echo "Installing browsers"
choco install firefox "%*"
choco install opera "%*"
choco install chromium "%*"
choco install midori-browser "%*"
choco install vivaldi "%*"
choco install microsoft-edge  "%*"
choco install brave  "%*"



cls
echo "Installing source control tools"
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
choco install deno "%*"
choco install bun "%*"
choco install microsoft-openjdk11 "%*"
choco install nodejs.install "%*"
choco install nvm "%*"
choco install ruby "%*"
choco install python2 "%*"
choco install python "%*"
choco install pyenv-win "%*" 
choco install jdk8 "%*"
choco install golang "%*"
choco install erlang "%*"
choco install dotnetcore-sdk "%*"
choco install dotnet-8.0-sdk "%*"
choco install elixir "%*"
choco install mono "%*"
choco install rust "%*"
choco install lua "%*"
choco install gtksharp "%*"
choco install julia "%*"
choco install android-sdk "%*"
choco install electron "%*"
@echo "GCC Compilier...."
choco install mingw "%*"
choco install make  "%*"

cls
echo "Installing Light weight editors"
choco install atom.install "%*"
choco install sublimetext4 "%*"
choco install vscode "%*"
choco install vscode-insiders "%*"
choco install brackets "%*"
choco install vim "%*"
choco install emacs "%*"
choco install micro "%*"
choco install scite "%*"


cls
echo "Installing Important Softwares and office utilities"
choco install autohotkey.install "%*"
choco install scrcpy "%*"
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
choco install httrack.app "%*"
choco install dropbox "%*"
choco install megasync "%*"
choco install pencil "%*"
choco install evernote  "%*"
choco install sysinternals "%*"
choco install skype "%*"
choco install slack "%*"
choco install microsoft-teams "%*"
choco install office365business "%*"
choco install libreoffice "%*"
choco install wps-office-free "%*"
choco install thunderbird "%*"
choco install projectlibre "%*"
choco install gimp "%*"
choco install mobaxterm "%*"
choco install teamviewer "%*"
choco install anydesk "%*"
choco install webex "%*"
choco install zoom "%*"
choco install paint.net  "%*"
choco install microsoft-windows-terminal "%*"
choco install rufus "%*"
choco install audacity "%*"
cls
echo "installing cool utilities"
choco install wget "%*"
choco install curl "%*"
choco install ffmpeg "%*"
choco install whois  "%*"
choco install openssl.light "%*"
choco install opencv "%*"
choco install ngrok "%*"

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
choco install mysql "%*"
choco install mysql.workbench "%*"
choco install apache-cassandra "%*"
choco install dbeaver "%*"
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
echo NOTE : VS 2017 2019 2022 available
choco install visualstudio2017community  "%*"
choco install visualstudio2019community  "%*"
choco install visualstudio2022community  "%*"
choco install r.studio "%*"
cls

echo "Other Server products"
choco install jenkins  "%*"
choco install rabbitmq "%*"
choco install nginx "%*"
choco install apache-httpd "%*"
choco install docker-desktop "%*"

echo "Installing Antivirus"
choco install avgantivirusfree "%*"
cls

echo "listing all choco packages"
choco list
pause


cls
echo "Happy coding and best luck."
pause
