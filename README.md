# Azure-Kubernetes
Udemy Course

Course reference : https://github.com/aspnetrun/run-devops

![image](https://github.com/user-attachments/assets/edf72745-952f-4c95-96bf-61724d289611)

![image](https://github.com/user-attachments/assets/a774c050-3e16-4178-a65f-92c3f0f6256b)


### Docker File / Docker Image and Docker Container

![image](https://github.com/user-attachments/assets/e379fe5b-7f02-4b9d-9e14-3c9832f131cc)


### Docker Commands

<b>docker images </b>   -> This displays images <br/>
<b>docker rmi [Part of Image Id] </b>  -> remove docker image by specifying couple of charaters of Imahe Id<br/>
<b>docker ps </b> -> displays all running containers<br/>
<b> docker stop [Part of container Id] </b>  -> To stop running container<br/>
<b> docker start [ContainerName] </b>  - To start container<br/>
<b> docker build -t [imageName] . </b>  --> If we are in the docker file location in the terminal it will refers DockerFile to build the image in the given name<br/>
<b> docker run -d -p 6069:8080 --name [containerName] [ExistingimageName]</b>  -> Create the container for that image<br/>  -> We can run the application stanalone without VS run


### Pushing the image to Docker hub
- We need to register on the Dockerhub
- Need to create a repository, here I created "shoppingapp"
- Open command prompt and goto the project directory and then login to Dockerhub using <b>docker login</b>, this will ask username and password and allow you to login
  ![image](https://github.com/user-attachments/assets/f6d347d7-1bf6-4bcf-99e3-90db6229bcbf)

- Before push the image to Dockerhub we need to Tag the Image, as part of this process
    - Get the latest image in release mode. If it in release more then the TAG will be "latest" else change the  VS project to Release mode than run in Docker mode OR run Docker build command
    - <b>docker tag [some charecters of ImageId] [Dockerhub repository Name]</b>    -> ex : <b>docker tag   e6852d newmancroos/shoppingapp</b>
      ![image](https://github.com/user-attachments/assets/846b088e-eaf6-41cb-b21f-a504209738e0)

      ![image](https://github.com/user-attachments/assets/84809922-b125-4009-8952-66040e38d983)

      After Tag the image it'll look lke this:
      ![image](https://github.com/user-attachments/assets/3334a46b-9611-4f2e-9cd4-f21c5b951473)
- Push Docker Image to Dockerhub
    - <b>docker push [imageName] : tag</b>   -> here it is <b>docker push newmancroos/shoppingapp:latest</b>

- After pushing to dockerhub, dockerhub repository looks like this:
  ![image](https://github.com/user-attachments/assets/a7109e2f-cd62-41a5-956a-bad9d1194db2)

  
### Deploy and run a Containerized web app with Azure App Service

-  Select <b>Web App for Containers</b> from Container menu and then create Web app using the Web app page

  ![image](https://github.com/user-attachments/assets/e7d89f43-f715-4711-992e-ff3c58c4e28a)
  

![image](https://github.com/user-attachments/assets/c07b56dc-3234-4a0a-bd8c-b1d3817ad1b8)

![image](https://github.com/user-attachments/assets/37d2e743-5215-4f58-badb-cd64368146f4)



- Select Other container in the Container tap, it will ask to specify the Image, In my case it is <b>/newmancroos/shoppingapp</b>

Once deployment completed the resource page looks like this.
![image](https://github.com/user-attachments/assets/51c77b92-ef69-4ba2-ab74-36096aec7c96)

Click the Default domain will take you to the actuual running web site.

Here we created Web app using Docker Hub without CICD.


Continue Integration Step:
1. Need to link Github repository in DockerHub ShoppingApp repository
2. In Azure Web app Deployment->Deployment Center, make Continus Deployment "On"
3. Copy Wenhook Url from Deployment Center
4. In Docker hub ShoppingApp repository select WebHoon tap and past the Wenhoop url
5. Now If we change anything in the code and push it to Github, Dockerhub identitify the change and rebuild the image and call the webhooks url so that image will be deploy to the Webapp.
        - Need to know: how to link Github with DockerHUb (It is available in Dockhub Pro) and how to specify DockerFile path in Dockhub build configuration


### Running Mongo in our local docker

- Check docker is running and list down all the running containers
    docker ps
- docker pull mongo   -> to pull mongo image
- docker run -d -p 27017:27017 --name shopping-mongo  mongo
      - mongo db default port is 27017
    This command will run the mongo database in docker
    - docker logs -f shopping-mongo   -> display the logs
-  docker exec -it mongoContainer mongosh   -> this will start the interactive terminal
                 - This will start iterative terminal
-  show  dbs   -> list down all databases
-  use CatalogDb  -> create CatalogDb database and switch to the dabase
-  db.createCollection('Products')    -> This will create Product collection (document table)
   <pre>
-  db.Products.insertMany([{'Name':'Asus Laptop', 'Category':'Computers', 'Summary':'Summary', 'Description':'Description', 'ImageFile':'ImageFile', 'Price': 54.93},{'Name':'HP Laptop', 'Category':'Computers', 'Summary':'Summary', 'Description':'Description', 'ImageFile':'ImageFile', 'Price': 88.93}])
-  </pre>
This command will insert two records into Products table.
- db.Products.find({}).pretty() -> listdown all the product
- db.Products.remove({})   ->  will delete all the records

-  show collections  -> listdown all tables
