#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["UI/BeerWulf.UI.Api/BeerWulf.UI.Api.csproj", "UI/BeerWulf.UI.Api/"]
RUN dotnet restore "UI/BeerWulf.UI.Api/BeerWulf.UI.Api.csproj"
COPY . .
WORKDIR "/src/UI/BeerWulf.UI.Api"
RUN dotnet build "BeerWulf.UI.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BeerWulf.UI.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BeerWulf.UI.Api.dll"]