#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/MarketplaceService.API/MarketplaceService.API.csproj", "src/MarketplaceService.API/"]
COPY ["src/EventsContracts/EventsContracts.csproj", "src/EventsContracts/"]
COPY ["src/MarketplaceService.Application/MarketplaceService.Application.csproj", "src/MarketplaceService.Application/"]
COPY ["src/MarketplaceService.Infrastructure/MarketplaceService.Infrastructure.csproj", "src/MarketplaceService.Infrastructure/"]
COPY ["src/MarketplaceService.Domain/MarketplaceService.Domain.csproj", "src/MarketplaceService.Domain/"]
RUN dotnet restore "./src/MarketplaceService.API/MarketplaceService.API.csproj"
COPY . .
WORKDIR "/src/src/MarketplaceService.API"
RUN dotnet build "./MarketplaceService.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./MarketplaceService.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MarketplaceService.API.dll"]