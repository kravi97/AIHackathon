#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/INTIME.Web.Public/INTIME.Web.Public.csproj", "src/INTIME.Web.Public/"]
COPY ["src/INTIME.Web.Core/INTIME.Web.Core.csproj", "src/INTIME.Web.Core/"]
COPY ["src/INTIME.Application/INTIME.Application.csproj", "src/INTIME.Application/"]
COPY ["src/INTIME.Application.Shared/INTIME.Application.Shared.csproj", "src/INTIME.Application.Shared/"]
COPY ["src/INTIME.Core.Shared/INTIME.Core.Shared.csproj", "src/INTIME.Core.Shared/"]
COPY ["src/INTIME.Core/INTIME.Core.csproj", "src/INTIME.Core/"]
COPY ["src/INTIME.EntityFrameworkCore/INTIME.EntityFrameworkCore.csproj", "src/INTIME.EntityFrameworkCore/"]
COPY ["src/INTIME.GraphQL/INTIME.GraphQL.csproj", "src/INTIME.GraphQL/"]
RUN dotnet restore "src/INTIME.Web.Public/INTIME.Web.Public.csproj"
COPY . .
WORKDIR "/src/src/INTIME.Web.Public"
RUN dotnet build "INTIME.Web.Public.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "INTIME.Web.Public.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "INTIME.Web.Public.dll"]
