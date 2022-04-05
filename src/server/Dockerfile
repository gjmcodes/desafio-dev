#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ENV PATH $PATH:/root/.dotnet/tools
ENV DOTNET_RUNNING_IN_CONTAINER=true
RUN dotnet new tool-manifest --name byc-tool-manifest
RUN dotnet tool install --global dotnet-ef
WORKDIR /src
COPY ["./ByC.API/ByC.REST/ByC.REST.csproj", "ByC.REST/"]
COPY ["./ByC.API/ByC.Domain/ByC.Domain.csproj", "ByC.Domain/"]
RUN dotnet ef database update
RUN dotnet restore  "ByC.REST/ByC.REST.csproj" --no-cache 


WORKDIR /src/ByC.REST

RUN dotnet build "./ByC.REST.csproj" -c Release -o /app/build
#RUN dotnet dotnet-ef database update 

#FROM build AS publish
#RUN dotnet publish "ByC.REST.csproj" -c Release -o /app/publish

#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "ByC.REST.dll"]