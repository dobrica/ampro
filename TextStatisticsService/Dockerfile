FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /TextStatisticsService

# Copy everything
COPY . ./
COPY ./Properties ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /TextStatisticsService
COPY --from=build-env /TextStatisticsService/out .

ENTRYPOINT ["dotnet", "TextStatisticsService.dll"]