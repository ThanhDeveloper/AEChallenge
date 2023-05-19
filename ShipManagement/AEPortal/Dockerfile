#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AEPortal/AEPortal.csproj", "AEPortal/"]
COPY ["AEPortal.Bussiness/AEPortal.Bussiness.csproj", "AEPortal.Bussiness/"]
COPY ["AEPortal.Data/AEPortal.Data.csproj", "AEPortal.Data/"]
COPY ["AEPortal.Common/AEPortal.Common.csproj", "AEPortal.Common/"]
RUN dotnet restore "AEPortal/AEPortal.csproj"
COPY . .
WORKDIR "/src/AEPortal"
RUN dotnet build "AEPortal.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AEPortal.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AEPortal.dll"]