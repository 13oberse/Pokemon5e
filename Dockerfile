FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "Pokemon5eBlazorJson/Pokemon5eBlazorJson.csproj"
RUN dotnet build "Pokemon5eBlazorJson/Pokemon5eBlazorJson.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Pokemon5eBlazorJson/Pokemon5eBlazorJson.csproj" -c Release -o /app/publish

FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot .
COPY --from=build /app/build/nginx.conf /etc/nginx/nginx.conf