# GraphQL Dotnet5 Api Example
### Features

- Containerized with Docker
- .NET 5.0
- Lightweight, Scalable

## Installation 

Download the project from github.

```sh
git clone https://github.com/yunusdgntr/dotnet5-graphQL
cd .\Net5-GraphQL\TodoListGraphQL
```
```sh
dotnet run
```
```sh
Browse https://localhost or http://localhost
```

## Docker Compose
Net5-GraphQL Api is very easy to install and deploy with docker-compose.
It easily runs docker-compose database and application together.
By default, the Docker will expose port 8000 and 8001, so change this within the 
docker-compose.yml if necessary. When ready, simply use the docker-compose.yml to
deploy the app.
```sh
cd Net5-GraphQL
docker-compose up --build -d
```
Verify the deployment by navigating to your server address in
your preferred browser.
```sh
https://localhost:8001
http://localhost:8000
```
## Docker

Net5-GraphQL Api is very easy to install and deploy in a Docker container.

By default, the Docker will expose port 80 and 443, so change this within the
Dockerfile if necessary. When ready, simply use the Dockerfile to
build the image.

```sh
cd Net5-GraphQL
docker build -t <youruser>/netgraphql:v1 .
```

This will create the netgraphql image and pull in the necessary dependencies.


Once done, run the Docker image and map the port to whatever you wish on
your host. In this example, we simply map port 8000 of the host to
port 8080 of the Docker (or whatever port was exposed in the Dockerfile):

```sh
docker run -d -p 8000:80 --restart=always --name=netgraphql <youruser>/netgraphql:v1
```

Verify the deployment by navigating to your server address in
your preferred browser.

```sh
http://localhost:8000
```
