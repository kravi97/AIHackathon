#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/INTIME.Migrator/INTIME.Migrator.csproj", "src/INTIME.Migrator/"]
COPY ["src/INTIME.EntityFrameworkCore/INTIME.EntityFrameworkCore.csproj", "src/INTIME.EntityFrameworkCore/"]
COPY ["src/INTIME.Core/INTIME.Core.csproj", "src/INTIME.Core/"]
COPY ["src/INTIME.Core.Shared/INTIME.Core.Shared.csproj", "src/INTIME.Core.Shared/"]
RUN dotnet restore "src/INTIME.Migrator/INTIME.Migrator.csproj"
COPY . .
WORKDIR "/src/src/INTIME.Migrator"
RUN dotnet build "INTIME.Migrator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "INTIME.Migrator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "INTIME.Migrator.dll", "-s"]
