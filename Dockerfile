FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Tracker.WebApi/Tracker.WebApi.csproj", "Tracker.WebApi/"]
COPY ["Tracker.Dal/Tracker.Dal.csproj", "Tracker.Dal/"]
COPY ["Tracker.Logic/Tracker.Logic.csproj", "Tracker.Logic/"]
RUN dotnet restore "Tracker.WebApi/Tracker.WebApi.csproj"
COPY . .
WORKDIR "/src/Tracker.WebApi"
RUN dotnet build "Tracker.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Tracker.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Tracker.WebApi.dll"]
