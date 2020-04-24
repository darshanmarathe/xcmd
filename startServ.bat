@echo off
C:
IF exist c:\data\db ( echo c:\data\db exists ) ELSE ( mkdir c:\data\db && echo c:\data\db created)
rem cd C:\Softwares\solr-5.3.1\bin
rem start solr start
cd C:\Program Files\MongoDB\Server\4.2\bin
start mongod
exit
