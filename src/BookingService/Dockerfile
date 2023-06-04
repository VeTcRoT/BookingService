FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore && dotnet publish -c Release -o publish
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS prod
WORKDIR /app
COPY --from=build /src/publish .
EXPOSE 8001
ENTRYPOINT ["dotnet", "BookingService.Api.dll"]
