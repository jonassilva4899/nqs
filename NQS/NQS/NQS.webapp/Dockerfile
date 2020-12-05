FROM node:12-alpine AS build
WORKDIR /src
COPY . .
WORKDIR /src/ClientApp
RUN npm install @elastic/apm-rum --save
RUN npm install
RUN npm run-script build-homolog


FROM nginx 
WORKDIR /usr/share/nginx/html
COPY --from=build /src/ClientApp/dist/fuse .
ADD ./nginx/nginx.conf  /etc/nginx/conf.d/default.conf
EXPOSE 80

