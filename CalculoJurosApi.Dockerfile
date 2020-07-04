FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app
EXPOSE 5000

COPY Softplan.CalculaJuros.Api/*.csproj ./Softplan.CalculaJuros.Api/
WORKDIR /app/Softplan.CalculaJuros.Api
RUN dotnet restore

WORKDIR /app/
COPY . ./
WORKDIR /app/Softplan.CalculaJuros.Api
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app
COPY --from=build /app/Softplan.CalculaJuros.Api/out ./
ENTRYPOINT ["dotnet", "Softplan.CalculaJuros.Api.dll"]