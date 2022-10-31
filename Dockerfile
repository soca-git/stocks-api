#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["src/Stocks/Stocks.csproj", "src/Stocks/"]
COPY ["src/Stocks.Controllers/Stocks.Controllers.csproj", "src/Stocks.Controllers/"]
COPY ["src/Stocks.IEXCloud/Stocks.IEXCloud.csproj", "src/Stocks.IEXCloud/"]
COPY ["src/Stocks.Api/Stocks.Api.csproj", "src/Stocks.Api/"]
COPY ["src/Stocks.Shared/Stocks.Shared.csproj", "src/Stocks.Shared/"]
COPY ["src/Stocks.Cache/Stocks.Cache.csproj", "src/Stocks.Cache/"]
COPY ["src/Stocks.NSwag/Stocks.NSwag.csproj", "src/Stocks.NSwag/"]
RUN dotnet restore "src/Stocks/Stocks.csproj"
COPY . .
WORKDIR "/src/src/Stocks"
RUN dotnet build "Stocks.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Stocks.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Stocks.dll