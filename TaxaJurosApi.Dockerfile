FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app
EXPOSE 5000

COPY Softplan.TaxaJuros.Api/*.csproj ./Softplan.TaxaJuros.Api/
WORKDIR /app/Softplan.TaxaJuros.Api
RUN dotnet restore

WORKDIR /app/
COPY . ./
WORKDIR /app/Softplan.TaxaJuros.Api
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app
COPY --from=build /app/Softplan.TaxaJuros.Api/out ./
ENTRYPOINT ["dotnet", "Softplan.TaxaJuros.Api.dll"]