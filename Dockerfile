FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY DigitalOwl.Api/*.csproj ./DigitalOwl.Api/
COPY DigitalOwl.Service/*.csproj ./DigitalOwl.Service/
COPY DigitalOwl.Repository/*.csproj ./DigitalOwl.Repository/
COPY DigitalOwl.Migrations/*.csproj ./DigitalOwl.Migrations/

COPY DigitalOwl.Database/*.csproj ./DigitalOwl.Database/
COPY DigitalOwl.Scripts/*.csproj ./DigitalOwl.Scripts/
COPY DigitalOwl.UnitTest/*.csproj ./DigitalOwl.UnitTest/
COPY DigitalOwl.WebAppClient/*.csproj ./DigitalOwl.WebAppClient/
RUN dotnet restore

# copy everything else and build app
COPY ./DigitalOwl.Api/ ./DigitalOwl.Api/
COPY ./DigitalOwl.Service/ ./DigitalOwl.Service/
COPY ./DigitalOwl.Repository/ ./DigitalOwl.Repository/
COPY ./DigitalOwl.Migrations/ ./DigitalOwl.Migrations/

COPY ./DigitalOwl.Database/ ./DigitalOwl.Database/
COPY ./DigitalOwl.Scripts/ ./DigitalOwl.Scripts/
COPY ./DigitalOwl.UnitTest/ ./DigitalOwl.UnitTest/
COPY ./DigitalOwl.WebAppClient/ ./DigitalOwl.WebAppClient/

WORKDIR /app/DigitalOwl.Api
RUN dotnet publish -c Development -o ../out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app
COPY --from=build /app/out ./
ENTRYPOINT ["dotnet", "DigitalOwl.Api.dll"]
