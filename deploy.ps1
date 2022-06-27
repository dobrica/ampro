# MongoDB - Templates
cd MongoDBConfig
docker build -t mongodb .
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
# export PATH=$PATH:/$HOME/.dotnet/tools
dotnet ef --version
dotnet ef database update
cd ..

# Init TemplateDB
docker exec -it ampro-ammongodb-1 mongoimport --db=TextTemplates --collection=Templates --type=csv --headerline --file=/templates.csv