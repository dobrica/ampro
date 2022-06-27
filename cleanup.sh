#!/bin/bash

docker stop $(docker ps -a -q --filter="name=ampro-*")

docker rm $(docker ps -a -q --filter="name=ampro-*")

docker rmi  $(docker images -f "dangling=true" -q)

docker rmi ampro_nginx messagesservice statisticsservice templatesservice mongodb amcapp

docker network rm ampro_amntwrk

sudo docker image rm node mcr.microsoft.com/dotnet/sdk:6.0 mcr.microsoft.com/dotnet/aspnet:6.0 mongo postgres nginx