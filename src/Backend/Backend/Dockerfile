#Build Stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . ./Backend
WORKDIR /src/Backend
RUN dotnet restore . && dotnet publish -c Release --property:PublishDir=/artifacts /p:UseAppHost=false --no-restore

#Run Stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /artifacts .

ENV DOTNET_NUGET_SIGNATURE_VERIFICATION=false
ENV ASPNETCORE_HTTP_PORTS=8083;

EXPOSE 8083

ENTRYPOINT ["dotnet", "Backend.Api.dll"]