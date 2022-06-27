#!/bin/bash

# MongoDB - Templates
cd MongoDBConfig
sudo docker build -t mongodb .
cd ..

# PostgresDB - Messages
cd PostgreSQLConfig
sudo docker compose run -d --name postgresqldb ampostgresdb
cd ..

# Build client image
cd Client
docker build -t amcapp .
cd ..

# Compose network, template and message db
docker compose -f docker-compose.networkanddb.yml up -d
# Compose services
docker compose up -d

# MessagesService
cd MessagesService
# Init MessageDB
export PATH=$PATH:/$HOME/.dotnet/tools
dotnet ef --version
dotnet ef database update
cd ..

# Init TemplateDB
docker exec -d ampro-ammongodb-1 chmod u+x ./startup.sh
docker exec -d ampro-ammongodb-1 ./startup.sh