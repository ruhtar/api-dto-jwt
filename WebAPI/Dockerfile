FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /WebAPI

COPY . ./
RUN dotnet restore

RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /WebAPI
COPY --from=build-env /WebAPI/out .
ENTRYPOINT ["dotnet", "SampleWebApplication.dll"]