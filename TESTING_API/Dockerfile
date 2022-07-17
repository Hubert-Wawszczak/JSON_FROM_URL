FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["TESTING_API/TESTING_API.csproj", "TESTING_API/"]
RUN dotnet restore "TESTING_API/TESTING_API.csproj"
COPY . .
WORKDIR "/src/TESTING_API"
RUN dotnet build "TESTING_API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TESTING_API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TESTING_API.dll"]
