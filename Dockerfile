FROM nginx:alpine AS final
EXPOSE 80 443
WORKDIR /usr/share/nginx/html
COPY index.html .
COPY nginx.conf /etc/nginx/nginx.conf
CMD ["nginx", "-g", "daemon off;"]