#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["User.Microservice.csproj", "User.Microservice/"]
RUN dotnet restore "User.Microservice/User.Microservice.csproj"
WORKDIR "/src/User.Microservice"
COPY . .
RUN dotnet build "User.Microservice.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "User.Microservice.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "User.Microservice.dll"]