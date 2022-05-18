#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["YouTube.Microservice/YouTube.Microservice.csproj", "YouTube.Microservice/"]
RUN dotnet restore "YouTube.Microservice/YouTube.Microservice.csproj"
COPY . .
WORKDIR "/src/YouTube.Microservice"
RUN dotnet build "YouTube.Microservice.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "YouTube.Microservice.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "YouTube.Microservice.dll"]