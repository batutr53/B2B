#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["B2B.TestAPI/B2B.TestAPI.csproj", "B2B.TestAPI/"]
RUN dotnet restore "B2B.TestAPI/B2B.TestAPI.csproj"
COPY . .
WORKDIR "/src/B2B.TestAPI"
RUN dotnet build "B2B.TestAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "B2B.TestAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "B2B.TestAPI.dll"]