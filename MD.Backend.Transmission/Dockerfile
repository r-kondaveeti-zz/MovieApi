#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY MD.Backend.Transmission/MD.Backend.Transmission.csproj MD.Backend.Transmission/
RUN dotnet restore "MD.Backend.Transmission/MD.Backend.Transmission.csproj"
COPY . .
WORKDIR "/src/MD.Backend.Transmission"
RUN dotnet build "MD.Backend.Transmission.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MD.Backend.Transmission.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MD.Backend.Transmission.dll"]
