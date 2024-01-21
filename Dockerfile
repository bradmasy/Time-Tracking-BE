# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["app-api.csproj", "."]
RUN dotnet restore "./app-api.csproj"

COPY . .
WORKDIR "/src/."
RUN dotnet build "app-api.csproj" -c Release -o /app/build

# Publish Stage
FROM build AS publish
RUN dotnet publish "app-api.csproj" -c Release -o /app/publish

# Runtime Stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet app-api.dll
