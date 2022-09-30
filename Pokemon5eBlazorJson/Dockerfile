FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Pokemon5eBlazorJson/Pokemon5eBlazorJson.csproj", "Pokemon5eBlazorJson/"]
RUN dotnet restore "Pokemon5eBlazorJson/Pokemon5eBlazorJson.csproj"
COPY . .
WORKDIR "/src/Pokemon5eBlazorJson"
RUN dotnet build "Pokemon5eBlazorJson.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Pokemon5eBlazorJson.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pokemon5eBlazorJson.dll"]
