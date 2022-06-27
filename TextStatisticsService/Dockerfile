FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /TextStatisticsService

EXPOSE 3500
ENV ASPNETCORE_URLS=http://+:3500

# Copy everything
COPY . ./
COPY ./Properties ./
COPY ./bin/Debug/net6.0/Swashbuckle.AspNetCore.Swagger* ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /TextStatisticsService
COPY --from=build-env /TextStatisticsService/out .

ENTRYPOINT ["dotnet", "TextStatisticsService.dll"]