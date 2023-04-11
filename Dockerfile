FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Backend.Shared.API/Backend.Shared.API.csproj", "Backend.Shared.API/"]
COPY ["Backend.Shared.BusinessRules/Backend.Shared.BusinessRules.csproj", "Backend.Shared.BusinessRules/"]
COPY ["Backend.Shared.Entities/Backend.Shared.Entities.csproj", "Backend.Shared.Entities/"]
COPY ["Backend.Shared.Repositories/Backend.Shared.Repositories.csproj", "Backend.Shared.Repositories/"]
COPY ["Backend.Shared.Utilities/Backend.Shared.Utilities.csproj", "Backend.Shared.Utilities/"]
RUN dotnet restore "Backend.Shared.API/Backend.Shared.API.csproj"
COPY . .
WORKDIR "/src/Backend.Shared.API"
RUN dotnet build "Backend.Shared.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Backend.Shared.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Backend.Shared.API.dll"]

