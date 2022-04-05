#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
RUN dotnet new tool-manifest --name byc-tool-manifest
RUN dotnet tool install --global dotnet-ef
COPY ["ByC.REST/ByC.REST.csproj", "ByC.REST/"]
COPY ["ByC.Domain/ByC.Domain.csproj", "ByC.Domain/"]
RUN dotnet restore "ByC.REST/ByC.REST.csproj"
COPY . .
WORKDIR "/src/ByC.REST"
RUN dotnet build "ByC.REST.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ByC.REST.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ByC.REST.dll"]