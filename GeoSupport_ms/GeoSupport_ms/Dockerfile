#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["GeoSupport_ms.csproj", "GeoSupport_ms/"]
RUN dotnet restore "GeoSupport_ms.csproj"
COPY . .
WORKDIR "/src/GeoSupport_ms"
RUN dotnet build "GeoSupport_ms.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GeoSupport_ms.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GeoSupport_ms.dll"]