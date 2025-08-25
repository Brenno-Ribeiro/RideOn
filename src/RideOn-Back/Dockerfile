# ====== Base image para rodar a aplicação ======
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# ====== Build image ======
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copiar todos os arquivos da solução
COPY . .

# Restaurar dependências da API (isso vai considerar todos os projetos referenciados)
RUN dotnet restore "RideOn.API/RideOn.API.csproj"

# Build de todos os projetos
WORKDIR "/src/RideOn.API"
RUN dotnet build "RideOn.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# ====== Publish ======
FROM build AS publish
WORKDIR "/src/RideOn.API"
RUN dotnet publish "RideOn.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# ====== Final image ======
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RideOn.API.dll"]
