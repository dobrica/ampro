#!/bin/bash

# TextStatisticsService
cd TextStatisticsService
sudo docker build -t statisticsservice .
sudo docker compose run -d --name statisticsservice web
cd ..

sudo docker image rm $(docker images -f "dangling=true" -q)

# PostgreSQL - MessageDB
cd PostgreSQLConfig
sudo docker compose run -d --name postgresqldb db
cd ..

sudo docker image rm $(docker images -f "dangling=true" -q)

# MongoDB - TemplatesDB
cd MongoDBConfig
sudo docker build -t mongodb .
sudo docker compose run -d --name mongodb mongo
sudo docker exec -d mongodb ./startup.sh
cd ..

sudo docker image rm $(docker images -f "dangling=true" -q)

# MessagesService
cd MessagesService
sudo docker build -t messagesservice .
sudo docker compose run -d --name messagesservice web2
# InitDB
dotnet ef database update
cd ..

sudo docker image rm $(docker images -f "dangling=true" -q)

# TemplatesService
cd TemplatesService
sudo docker build -t templatesservice .
sudo docker compose run -d --name templatesservice web1
cd ..

sudo docker image rm $(docker images -f "dangling=true" -q)

# Angular - Client
cd Client
sudo docker build -t amcapp .
sudo docker compose run -d --name amcapp app
cd ..

sudo docker image rm $(docker images -f "dangling=true" -q)