FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /TemplatesService

EXPOSE 3700
ENV ASPNETCORE_URLS=http://+:3700
ENV ASPNETCORE_ENVIRONMENT=Development

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /TemplatesService
COPY --from=build-env /TemplatesService/out .

ENTRYPOINT ["dotnet", "TemplatesService.dll"]