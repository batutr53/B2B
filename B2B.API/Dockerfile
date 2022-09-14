#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["B2B.API/B2B.API.csproj", "B2B.API/"]
COPY ["B2B.DataAccess/B2B.DataAccess.csproj", "B2B.DataAccess/"]
COPY ["B2B.Entities/B2B.Entities.csproj", "B2B.Entities/"]
COPY ["B2B.Core/B2B.Core.csproj", "B2B.Core/"]
COPY ["B2B.SharedTools/B2B.SharedTools.csproj", "B2B.SharedTools/"]
COPY ["B2B.Business/B2B.Business.csproj", "B2B.Business/"]
RUN dotnet restore "B2B.API/B2B.API.csproj"
COPY . .
WORKDIR "/src/B2B.API"
RUN dotnet build "B2B.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "B2B.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "B2B.API.dll"]