# created:    20260412 / alphabeit
# lastupdate: 20260413 / alphabeit

# https://blog.dotnethow.net/containerizing-your-net-application-with-docker/

# Use the official .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ./backend .

RUN dotnet add package Microsoft.EntityFrameworkCore
RUN dotnet add package Microsoft.EntityFrameworkCore.SqlServer
RUN dotnet add package Microsoft.EntityFrameworkCore.Tools
RUN dotnet add package Microsoft.Extensions.Configuration
RUN dotnet add package Microsoft.Extensions.Configuration.FileExtensions
RUN dotnet add package Microsoft.Extensions.Configuration.Json

RUN dotnet restore
RUN dotnet publish -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY ./backend/appsettings.json .
COPY --from=build /app .
EXPOSE 80

ENTRYPOINT ["dotnet", "/app/backend.dll"]
