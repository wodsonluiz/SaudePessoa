FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["SaudePessoa.Api/SaudePessoa.Api.csproj", "SaudePessoa.Api/"]
COPY ["SaudePessoa.Data/SaudePessoa.Data.csproj", "SaudePessoa.Data/"]
RUN dotnet restore "SaudePessoa.Api/SaudePessoa.Api.csproj"
COPY . .
WORKDIR "/src/SaudePessoa.Api"
RUN dotnet build "SaudePessoa.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "SaudePessoa.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SaudePessoa.Api.dll"]