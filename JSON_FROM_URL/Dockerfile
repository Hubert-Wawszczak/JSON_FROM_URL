FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["JSON_FROM_URL/JSON_FROM_URL.csproj", "JSON_FROM_URL/"]
RUN dotnet restore "JSON_FROM_URL/JSON_FROM_URL.csproj"
COPY . .
WORKDIR "/src/JSON_FROM_URL"
RUN dotnet build "JSON_FROM_URL.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "JSON_FROM_URL.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "JSON_FROM_URL.dll"]
