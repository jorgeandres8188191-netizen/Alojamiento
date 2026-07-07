# Etapa 1: Construcción común
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar archivo de solución
COPY GestionHoteles.sln .

# Copiar TODOS los archivos .csproj
COPY asp_presentacion/*.csproj ./asp_presentacion/
COPY asp_servicios/*.csproj ./asp_servicios/
COPY lib_aplicaciones/*.csproj ./lib_aplicaciones/
COPY lib_dominio/*.csproj ./lib_dominio/
COPY lib_presentaciones/*.csproj ./lib_presentaciones/
COPY lib_repositorios/*.csproj ./lib_repositorios/
COPY ut_presentacion/*.csproj ./ut_presentacion/

# Restaurar dependencias
RUN dotnet restore ./GestionHoteles.sln

# Copiar TODO el código fuente
COPY . .

# ============================================
# Etapa 2: Publicar la API (asp_servicios)
# ============================================
FROM build AS publish-api
RUN dotnet publish ./asp_servicios/asp_servicios.csproj -c Release -o /app/publish-api

# ============================================
# Etapa 3: Publicar la Web (asp_presentacion)
# ============================================
FROM build AS publish-web
RUN dotnet publish ./asp_presentacion/asp_presentacion.csproj -c Release -o /app/publish-web

# ============================================
# Etapa 4: Imagen final para la API
# ============================================
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS api
WORKDIR /app
COPY --from=publish-api /app/publish-api .
ENV ASPNETCORE_ENVIRONMENT=Production
ENV ASPNETCORE_URLS=http://+:5297
EXPOSE 5297
ENTRYPOINT ["dotnet", "asp_servicios.dll"]

# ============================================
# Etapa 5: Imagen final para la Web
# ============================================
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS web
WORKDIR /app
COPY --from=publish-web /app/publish-web .
ENV ASPNETCORE_ENVIRONMENT=Production
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080
ENTRYPOINT ["dotnet", "asp_presentacion.dll"]