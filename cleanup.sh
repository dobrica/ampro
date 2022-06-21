#!/bin/bash
sudo docker stop amcapp templatesservice messagesservice mongodb postgresqldb statisticsservice

sudo docker rm amcapp templatesservice messagesservice mongodb postgresqldb statisticsservice

sudo docker image rm amcapp templatesservice messagesservice mongodb postgresqldb statisticsservice 

sudo docker image rm node mcr.microsoft.com/dotnet/sdk:6.0 mcr.microsoft.com/dotnet/aspnet:6.0 mongo postgres nginx

sudo docker image rm  $(sudo docker images -f "dangling=true" -q)