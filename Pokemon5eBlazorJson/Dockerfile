FROM mcr.microsoft.com/dotnet/sdk:6.0 AS publish
EXPOSE 80 443
COPY . .
RUN dotnet publish "Pokemon5eBlazorJson/Pokemon5eBlazorJson.csproj" -c Release -o /app/publish

FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot .
COPY --from=publish /app/publish/nginx.conf /etc/nginx/nginx.conf
CMD ["nginx", "-g", "daemon off;"]