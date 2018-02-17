echo "installing nessesary software"
apt update
apt upgrade -y
apt autoremove 
apt install vim -y
apt-get update apt install wget -y
apt install curl -y 
clear
echo "installing kong"
echo "deb http://www.apache.org/dist/cassandra/debian 311x main" | sudo tee -a /etc/apt
sources.list.d/cassandra.sources.list 
curl https://www.apache.org/dist/cassandra/KEYS | sudo apt-key add - 
apt update
apt install cassandra
service cassandra start 
chkconfig cassandra on 
echo "installing cassandra done"
clear
echo "Installing and configuring kong"
wget https://bintray.com/kong/kong-community-edition-deb/download_file?file_path=dists
kong-community-edition-0.12.1.zesty.all.deb
apt install dpkg openssl libpcre3 procps perl
dpkg -i kong-community-edition-0.12.1.*.deb
cd /etc/kong
wget https://raw.githubusercontent.com/darshanmarathe/xcmd/master/kong.conf
kong migrations up kong.conf
kong start kong.konf
