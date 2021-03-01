# escape=`

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app

# copy proyects and restore as distinct layers
COPY *.sln .
COPY src/.   ./src/
RUN dotnet restore

# build the app
WORKDIR /app/src/Hahn.ApplicationProcess.February2021.Web
RUN dotnet publish -c debug -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS publish

WORKDIR /app
COPY --from=build /app ./

# Expose the port in the container
EXPOSE 80
# Expose the port in ASP.Net Core
ENV ASPNETCORE_URLS=http://*:80

ENTRYPOINT ["dotnet", "KHahn.ApplicationProcess.February2021.Web.dll"]