FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim-arm32v7

COPY bin/Release/netcoreapp3.1/publish/ App/

WORKDIR /App

EXPOSE 80

ENTRYPOINT ["dotnet", "MD.Backend.Api.IndianMovies.dll"]
