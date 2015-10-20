@ECHO OFF

REM The Following directory is for MongoDB
Cd C:\Program Files\MongoDB\Server\3.0\bin

echo Seed Inicialize colletions [Books] MongoDB

mongo.exe ..\seedscript.js

echo ###################################################################################
echo Done.
pause

