# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
#EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["backend/services/MarketplaceService/src/MarketplaceService.API/MarketplaceService.API.csproj", "backend/services/MarketplaceService/src/MarketplaceService.API/"]
COPY ["backend/contacts/EventsContracts/EventsContracts.csproj", "backend/contacts/EventsContracts/"]
COPY ["backend/services/MarketplaceService/src/MarketplaceService.Application/MarketplaceService.Application.csproj", "backend/services/MarketplaceService/src/MarketplaceService.Application/"]
COPY ["backend/services/MarketplaceService/src/MarketplaceService.Domain/MarketplaceService.Domain.csproj", "backend/services/MarketplaceService/src/MarketplaceService.Domain/"]
COPY ["backend/services/MarketplaceService/src/MarketplaceService.Infrastructure/MarketplaceService.Infrastructure.csproj", "backend/services/MarketplaceService/src/MarketplaceService.Infrastructure/"]
RUN dotnet restore "./backend/services/MarketplaceService/src/MarketplaceService.API/MarketplaceService.API.csproj"
COPY . .
WORKDIR "/src/backend/services/MarketplaceService/src/MarketplaceService.API"
RUN dotnet build "./MarketplaceService.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./MarketplaceService.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MarketplaceService.API.dll"]