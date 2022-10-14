# FROM mcr.microsoft.com/dotnet/sdk:6.0 AS publish
# COPY . .
# RUN dotnet publish "Pokemon5eBlazorJson/Pokemon5eBlazorJson.csproj" -c Release -o /app/publish

FROM docker.io/library/nginx:alpine AS final
EXPOSE 80 443
WORKDIR /usr/share/nginx/html
COPY index.html .
#COPY --from=publish "/app/publish/wwwroot" Pokemon5eJson
#COPY "/Pokemon5eBlazorJson/publish/wwwroot" Pokemon5eJson
COPY nginx.conf /etc/nginx/nginx.conf
CMD ["nginx", "-g", "daemon off;"]