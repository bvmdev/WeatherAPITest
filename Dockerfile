﻿FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 4000
EXPOSE 4001

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["WeatherForecastApi.csproj", "./"]
RUN dotnet restore "WeatherForecastApi.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "WeatherForecastApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WeatherForecastApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WeatherForecastApi.dll"]
