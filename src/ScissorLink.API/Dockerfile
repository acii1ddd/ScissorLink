FROM mcr.microsoft.com/dotnet/aspnet:10.0-alpine AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:10.0-alpine AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/ScissorLink.API/ScissorLink.API.csproj", "src/ScissorLink.API/"]
COPY ["src/ScissorLink.DAL.MariaDB/ScissorLink.DAL.MariaDB.csproj", "src/ScissorLink.DAL.MariaDB/"]
COPY ["src/ScissorLink.BLL/ScissorLink.BLL.csproj", "src/ScissorLink.BLL/"]
RUN dotnet restore "src/ScissorLink.API/ScissorLink.API.csproj"
COPY . .
WORKDIR "/src/src/ScissorLink.API"
RUN dotnet build "./ScissorLink.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ScissorLink.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ScissorLink.API.dll"]
