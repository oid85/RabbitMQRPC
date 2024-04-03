FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
COPY . /app
WORKDIR /app
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "RabbitMQRPC.Sample.dll"]