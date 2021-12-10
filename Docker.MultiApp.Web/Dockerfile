#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Docker.MultiApp.Web/Docker.MultiApp.Web.csproj", "Docker.MultiApp.Web/"]
COPY ["Docker.MultiApp.API/Docker.MultiApp.API.csproj", "Docker.MultiApp.API/"]
RUN dotnet restore "Docker.MultiApp.Web/Docker.MultiApp.Web.csproj"
COPY . .
WORKDIR "/src/Docker.MultiApp.Web"
RUN dotnet build "Docker.MultiApp.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Docker.MultiApp.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Docker.MultiApp.Web.dll"]
