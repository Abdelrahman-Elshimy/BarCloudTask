## Steps to Build / Run on Docker

Open a terminal and run the following command inside the project's root folder, where the Dockerfile is placed.
Now build the container image using the docker build command.
```sh
docker build -t barcloud-task .
```
After the image is finished building, you can check if it's listed as a local Docker image using the following command:
```sh
docker images
```
To run the newly created Docker image, use the following command:
```sh
docker run --name barcloudtaks-api -d -p 5500:80 barcloud-task
```

To check the running Docker container, use the following command:
```sh
docker ps
```
To execute command inside the docker container
```sh
docker exec -it [container-id] sh
```
## Steps to Build / Run on Docker compose

Open a terminal and run the following command inside the project's root folder, where the docker-compose is placed.
Now build the compose using the build command.
```sh
docker-compose build
```

To run it, use the following command:
```sh
docker-compose up -d
```
The -d option specifies that the containers should be run in the background (Detached mode).


#Hint : Please Notice to update migration to new connection string and update-database