# created:    20260412 / alphabeit
# lastupdate: 20260415 / alphabeit

# See also as ref https://blog.dotnethow.net/containerizing-your-net-application-with-docker/

# Use the official .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ./backend .

# install dependencies
RUN dotnet add package Microsoft.AspNetCore.OpenApi
RUN dotnet add package Microsoft.AspNetCore.Mvc

RUN dotnet add package Microsoft.EntityFrameworkCore
RUN dotnet add package Microsoft.EntityFrameworkCore.SqlServer
RUN dotnet add package Microsoft.EntityFrameworkCore.Tools
RUN dotnet add package Microsoft.EntityFrameworkCore.Design

RUN dotnet add package Microsoft.Extensions.Configuration
RUN dotnet add package Microsoft.Extensions.Configuration.FileExtensions
RUN dotnet add package Microsoft.Extensions.Configuration.Json

# build backend
RUN dotnet restore
RUN dotnet publish -c Release -o /app

# build env for backend
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY ./backend/appsettings.json .
COPY --from=build /app .
EXPOSE 8080

# run backend
ENTRYPOINT ["dotnet", "/app/backend.dll"]
