#!/bin/bash

# MongoDB - Templates
cd MongoDBConfig
sudo docker build -t mongodb .
cd ..

# PostgresDB - Messages
cd PostgreSQLConfig
sudo docker build -t postgresdb .
cd ..

# Build client image
cd Client
docker build -t amcapp .
cd ..

# Compose network, template and message db
docker compose -f docker-compose.networkanddb.yml up -d
# Compose services
docker compose up -d

# Init MessagesDB
docker exec -d ampro-ampostgresdb-1 psql -U postgres -d ttemplates -f init.sql

# Init TemplateDB
docker exec -d ampro-ammongodb-1 chmod u+x ./startup.sh
docker exec -d ampro-ammongodb-1 ./startup.sh