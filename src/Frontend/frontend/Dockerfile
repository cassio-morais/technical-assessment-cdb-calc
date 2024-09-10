# Docker just for development mode
FROM node:alpine

WORKDIR /app

COPY . /app

RUN npm install -g @angular/cli &&  npm install

EXPOSE 4200

CMD ["ng", "serve", "--host", "0.0.0.0"]