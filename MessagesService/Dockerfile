FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /MessagesService

EXPOSE 3600
ENV ASPNETCORE_URLS=http://+:3600

# Copy everything
COPY . ./
COPY ./bin/Debug/net6.0/Swashbuckle.AspNetCore.Swagger* ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /MessagesService
COPY --from=build-env /MessagesService/out .
RUN 

ENTRYPOINT ["dotnet", "MessagesService.dll"]