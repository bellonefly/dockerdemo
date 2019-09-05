# build stage
FROM node:lts-alpine as build-stage
WORKDIR /app
COPY FrontStage.Web/package*.json ./
RUN npm install
COPY ./FrontStage.Web .
ARG env
RUN npm run $env

# production stage
FROM nginx:stable-alpine as production-stage
COPY --from=build-stage /app/dist /usr/share/nginx/html
RUN rm /etc/nginx/conf.d/default.conf
COPY ./FrontStage.Web/nginx/conf.d/nginx.conf /etc/nginx/conf.d/
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]
