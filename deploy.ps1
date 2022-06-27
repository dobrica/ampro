# MongoDB - Templates
cd MongoDBConfig
docker build -t mongodb .
cd ..

# PostgresDB - Messages
cd PostgreSQLConfig
docker build -t postgresdb .
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
docker exec -it ampro-ammongodb-1 mongoimport --db=TextTemplates --collection=Templates --type=csv --headerline --file=/templates.csv