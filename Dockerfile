FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

#COPY *.csproj .
#RUN dotnet restore NixMdm.csproj

COPY . .

RUN dotnet publish -o build
# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:3.1

WORKDIR /app/build
COPY --from=build-env /app .

ENTRYPOINT ["dotnet", "build/NixMdm.dll"]