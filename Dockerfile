FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env

WORKDIR /api
COPY *.csproj ./
RUN dotnet restore

COPY * ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /api
COPY --from=build-env /api/out .

ENV ASPNETCORE_ENVIRONMENT=Development
ENV ASPNETCORE_URLS=http://+:80;https://+:443
ENV ASPNETCORE_HTTPS_PORT=443
ENV ASPNETCORE_Kestrel__Certificates__Default__Password=f25697rujfo67r
ENV ASPNETCORE_Kestrel__Certificates__Default__Path=/https/certificate.pfx
ENV DATABASE_CONNECTION Host=docker;Database=FoodDB;Username=postgres;Password=C4wdjcPVnH;
ENV JWT_SECRET LApFZbVvLjPhLLnjdZ7ukhp2J86NbPCt

ENTRYPOINT [ "dotnet", "fahlen_dev_webapi.dll" ]