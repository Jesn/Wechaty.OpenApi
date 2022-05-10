#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["NuGet.Config", "."]
COPY ["host/Wechaty.OpenApi.HttpApi.Host/Wechaty.OpenApi.HttpApi.Host.csproj", "host/Wechaty.OpenApi.HttpApi.Host/"]
COPY ["src/Wechaty.OpenApi.Application/Wechaty.OpenApi.Application.csproj", "src/Wechaty.OpenApi.Application/"]
COPY ["src/Wechaty.OpenApi.Application.Contracts/Wechaty.OpenApi.Application.Contracts.csproj", "src/Wechaty.OpenApi.Application.Contracts/"]
COPY ["src/Wechaty.OpenApi.HttpApi/Wechaty.OpenApi.HttpApi.csproj", "src/Wechaty.OpenApi.HttpApi/"]
RUN dotnet restore "host/Wechaty.OpenApi.HttpApi.Host/Wechaty.OpenApi.HttpApi.Host.csproj"
COPY . .
WORKDIR "/src/host/Wechaty.OpenApi.HttpApi.Host"
RUN dotnet build "Wechaty.OpenApi.HttpApi.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Wechaty.OpenApi.HttpApi.Host.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Wechaty.OpenApi.HttpApi.Host.dll"]