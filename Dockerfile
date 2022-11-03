FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

WORKDIR /App

COPY . .

RUN dotnet restore

ENTRYPOINT ["dotnet", "run"]

# dotnet publish -c Release -o out