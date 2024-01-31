FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copia los archivos csproj y restaura las dependencias
COPY ["N5-Web-Api/N5-Web-Api.csproj", "N5-Web-Api/"]
COPY ["Application/Application.csproj", "Application/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]
RUN dotnet restore "N5-Web-Api/N5-Web-Api.csproj"

# Copia los archivos del proyecto
COPY . .

# Cambia al directorio del proyecto de la API y construye la aplicación
WORKDIR "/src/N5-Web-Api"
RUN dotnet build "N5-Web-Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "N5-Web-Api.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "N5-Web-Api.dll"]
