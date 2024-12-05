FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build_env
WORKDIR /App
COPY *.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /App

EXPOSE 80

COPY --from=build_env /App/out .
ENTRYPOINT [ "dotnet", "API.dll" ]