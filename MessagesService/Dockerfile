FROM mcr.microsoft.com/dotnet/sdk:6.0
WORKDIR /MessagesService

RUN dotnet tool install -g dotnet-ef
ENV PATH $PATH:/root/.dotnet/tools
RUN dotnet ef --version

# Copy everything
COPY . ./
COPY ./Properties ./
RUN chmod u+x startup.sh
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out

ENTRYPOINT ["./startup.sh"]