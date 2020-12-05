FROM node:12-alpine AS build
WORKDIR /src
COPY . .
WORKDIR /src/ClientApp
RUN npm install
RUN npm run-script build


FROM nginx AS final
WORKDIR /usr/share/nginx/html
COPY --from=build /src/ClientApp/dist/fuse .
EXPOSE 80
