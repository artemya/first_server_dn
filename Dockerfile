# https://hub.docker.com/_/microsoft-dotnet-core
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln .
COPY first_server_dn/*.csproj ./first_server_dn/
RUN dotnet restore

# copy everything else and build app
COPY first_server_dn/. ./first_server_dn/
WORKDIR /source/first_server_dn
RUN dotnet publish -c Release -o /app 

# final stage/image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "first_server_dn.dll"]
