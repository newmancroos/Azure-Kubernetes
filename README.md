# Azure-Kubernetes
Helpful Easy explanation : https://www.youtube.com/watch?v=aiUrjgJjLOw
![image](https://github.com/user-attachments/assets/9a2017f4-60bc-4715-a144-c687e46873c8)


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
-  docker exec -it [mongoContainerName] mongosh   -> this will start the interactive terminal
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


### To work with Mongodb we need to install Nuget package MongoDb.Driver

![image](https://github.com/user-attachments/assets/cb5b207a-c000-4e23-ba78-fd607631bd65)

![image](https://github.com/user-attachments/assets/121d30ce-5faa-48e3-86e1-c9cedb81a53f)



![image](https://github.com/user-attachments/assets/fb273144-94c3-4247-bcad-a18550f3021b)



- Deploy all docker containers
     * docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d
     * If we have multiple environments we can have docker-compose.Staging, docker-compose.Prod and then can run <br>
           <b>docker-compose -f docker-compose.yml -f docker-compose.Staging.yml up -d </b><br/>
- Stop all containers
     * docker-compose -f docker-compose.yml -f docker-compose.override.yml down

## To practice Kubernetes, we can download and install MiniKube. It is work on top of Docker

* Websire for Down load https://minikube.sigs.k8s.io/docs/start/?arch=%2Fwindows%2Fx86-64%2Fstable%2F.exe+download 
* To start minukube after install : **minikube start**

## Kubernetes (K8s)

- Kubernetes lets you create, deploy, manage, and scale application containers across one or more host clusters. 
- Open-Source container orchestration platform
- Automated many of the manual process
- Deploying, managing and Scaling containerized application
- Monitors applications & Manages workloads across multiple machines



  ### Kubernetes Components 

![image](https://github.com/user-attachments/assets/cd7af4f4-3aeb-46c8-b925-066e57d5cd98)

![image](https://github.com/user-attachments/assets/8e6cda51-8d65-4d20-9a2c-84bfbb69cc9f)

<b>Kubernetes cluster has two main components</b>
  - The Control Plane    -> Hosts the components used to manage the kubernetes cluster
  - Worker Nodes    -> Can be Virtual machine or Physical machines. A Node hosts Pods, which run one or more containers.

<b><u>The Control Plane</u></b>
<p>
The control plane includes components like the API Server, Scheduler, and Controller Manager. The control plane maintains communication with worker nodes. When you deploy applications on Kubernetes, you tell the control plane to start the application’s containers. The control plane then schedules the containers to run on the cluster’s nodes.

Technically speaking, the Kubernetes control plane is a collection of processes that manages the state of a Kubernetes cluster. It receives information about cluster activity and requests, and uses this information to move cluster resources to the desired state. The control plane interacts with individual cluster nodes using the kubelet, an agent deployed on each node.

To have a highly available control plane, you should have at least three control plane nodes with the components replicated across all three nodes.
</p>
<b>Control Plane has the following Components</b><br/>
  - <b>API Server</b> -> <p>Provides an API that serves as the front end of a kubernetes control pane. It is responsible for handling external and internal request. API can be access via the Kubectl command-line interface or other tools like Kubeadm or via REST calls. </p><br/>
  - <b>Scheduler</b> -> <p>Responsible for scheduling PODs on a specific nodes to automated workflows and user define conditions.</p><br>
  -  Kubernetes Controller Manager -> <p>Is a Control loop that monitors and regulate the state of a Kubernetes cluster.</p><br/>
  - <b>etcd</b> - <p>A Key-Value database that contains data abou your cluster state and configuration. Etcd is fault tolerant and distributed.</p><br/>
  - <b>Cloud Controller Manager</b> - <p>This component can be embed Clo;ud-specific control logic. ex. It can the cloud provider's load balance service. </p> <br/>

<b><u>Worker Nodes</u></b><br/>
  Worker nodes has the following components<br/>
- <b>Nodes</b> -> <p>Nodes are physical or virtual machines that run pods of a Kubernetes cluster. A cluster can scale upto 5000 nodes. To scale a cluster's capacity, you can add more nodes.</p><br/>
- <b>Pods</b> -> <p>A Pod serves as a single application instance, and is considered the smallest unit in the object model of kubernetes.Each Pods consists of one or more tighly coupled cointainers and configurations that govern how the containers should run.To run statefull application, you can connect pods to persistent storage using kubernetes persitent valums.</p><br/>
- <b>Container Runtime Engine</b> <p>Each node comes with a container runtime engine which is responsible for running containers. Docker is a popular container runtime engine but other runtimes that are compliant with open cointainer initiative including CRI-O and RKT. </p><br/>
- <b>Kubelt</b> <p>Each node contains a kubelt, which is a small application that can communicate with Kubernetes control plane. The Kubelet is responsible for enduring theat containers specified in pod configuration are running on a specific node and manage their lifecycle.</p><br/>
- <b>kube-proxy</b><p>All compute nodes contains Kube-Proxy, a network proxy that facilitates Kubernetes networking services. It handle all network communications outside and inside the cluster, forwarding traffic or replying on the packet filtering layer of the operating system</p><br/>
- <b>Container Networking</b> <p>Enables containers to communicate with hosts or other containers. Often achived by using the container networking interface (CNI)</p><br/>

### Kubernetes Commands

- kubectl get all   -> display kubernetes services running
![image](https://github.com/user-attachments/assets/c5c391ff-d7fe-42fe-b9f8-c4da01ccf0ce)


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
-  docker exec -it [mongoContainerName] mongosh   -> this will start the interactive terminal
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


### To work with Mongodb we need to install Nuget package MongoDb.Driver

![image](https://github.com/user-attachments/assets/cb5b207a-c000-4e23-ba78-fd607631bd65)

![image](https://github.com/user-attachments/assets/121d30ce-5faa-48e3-86e1-c9cedb81a53f)



![image](https://github.com/user-attachments/assets/fb273144-94c3-4247-bcad-a18550f3021b)



- Deploy all docker containers
     * docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d
     * If we have multiple environments we can have docker-compose.Staging, docker-compose.Prod and then can run <br>
           <b>docker-compose -f docker-compose.yml -f docker-compose.Staging.yml up -d </b><br/>
- Stop all containers
     * docker-compose -f docker-compose.yml -f docker-compose.override.yml down


## Kubernetes (K8s)

- Kubernetes lets you create, deploy, manage, and scale application containers across one or more host clusters. 
- Open-Source container orchestration platform
- Automated many of the manual process
- Deploying, managing and Scaling containerized application
- Monitors applications & Manages workloads across multiple machines



  ### Kubernetes Components 

![image](https://github.com/user-attachments/assets/cd7af4f4-3aeb-46c8-b925-066e57d5cd98)

![image](https://github.com/user-attachments/assets/8e6cda51-8d65-4d20-9a2c-84bfbb69cc9f)

<b>Kubernetes cluster has two main components</b>
  - The Control Plane    -> Hosts the components used to manage the kubernetes cluster
  - Worker Nodes    -> Can be Virtual machine or Physical machines. A Node hosts Pods, which run one or more containers.

<b><u>The Control Plane</u></b>
<p>
The control plane includes components like the API Server, Scheduler, and Controller Manager. The control plane maintains communication with worker nodes. When you deploy applications on Kubernetes, you tell the control plane to start the application’s containers. The control plane then schedules the containers to run on the cluster’s nodes.

Technically speaking, the Kubernetes control plane is a collection of processes that manages the state of a Kubernetes cluster. It receives information about cluster activity and requests, and uses this information to move cluster resources to the desired state. The control plane interacts with individual cluster nodes using the kubelet, an agent deployed on each node.

To have a highly available control plane, you should have at least three control plane nodes with the components replicated across all three nodes.
</p>
<b>Control Plane has the following Components</b><br/>
  - <b>API Server</b> -> <p>Provides an API that serves as the front end of a kubernetes control pane. It is responsible for handling external and internal request. API can be access via the Kubectl command-line interface or other tools like Kubeadm or via REST calls. </p><br/>
  - <b>Scheduler</b> -> <p>Responsible for scheduling PODs on a specific nodes to automated workflows and user define conditions.</p><br>
  -  Kubernetes Controller Manager -> <p>Is a Control loop that monitors and regulate the state of a Kubernetes cluster.</p><br/>
  - <b>etcd</b> - <p>A Key-Value database that contains data abou your cluster state and configuration. Etcd is fault tolerant and distributed.</p><br/>
  - <b>Cloud Controller Manager</b> - <p>This component can be embed Clo;ud-specific control logic. ex. It can the cloud provider's load balance service. </p> <br/>

<b><u>Worker Nodes</u></b><br/>
  Worker nodes has the following components<br/>
- <b>Nodes</b> -> <p>Nodes are physical or virtual machines that run pods of a Kubernetes cluster. A cluster can scale upto 5000 nodes. To scale a cluster's capacity, you can add more nodes.</p><br/>
- <b>Pods</b> -> <p>A Pod serves as a single application instance, and is considered the smallest unit in the object model of kubernetes.Each Pods consists of one or more tighly coupled cointainers and configurations that govern how the containers should run.To run statefull application, you can connect pods to persistent storage using kubernetes persitent valums.</p><br/>
- <b>Container Runtime Engine</b> <p>Each node comes with a container runtime engine which is responsible for running containers. Docker is a popular container runtime engine but other runtimes that are compliant with open cointainer initiative including CRI-O and RKT. </p><br/>
- <b>Kubelt</b> <p>Each node contains a kubelt, which is a small application that can communicate with Kubernetes control plane. The Kubelet is responsible for enduring theat containers specified in pod configuration are running on a specific node and manage their lifecycle.</p><br/>
- <b>kube-proxy</b><p>All compute nodes contains Kube-Proxy, a network proxy that facilitates Kubernetes networking services. It handle all network communications outside and inside the cluster, forwarding traffic or replying on the packet filtering layer of the operating system</p><br/>
- <b>Container Networking</b> <p>Enables containers to communicate with hosts or other containers. Often achived by using the container networking interface (CNI)</p><br/>

### Kubernetes Commands

- kubectl get all   -> display kubernetes services running
![image](https://github.com/user-attachments/assets/638a36be-f3ee-479e-a1bf-94859d511d29)


- In Imperative way, we are telling the kubernetes to immediatly run our image from the repository
- In Declarative way we have a configuration file that has set of commands to run

  
- For example here we are running Nginx web server in imperative way
  ![image](https://github.com/user-attachments/assets/74ad5848-f98d-497d-b089-f6fa8e8f98a8)

  here <b>kubctl run swn-nginx --image=nginx </b> directly download and create pod and runs Nginx on the pod.

- Nginx web server default port is 80 we can forward it to 8080 and check the nginx server running as blow:
  ![image](https://github.com/user-attachments/assets/dbe98f9b-ce1b-4b45-8c12-64f9143fb9af)
  
- It is imerative way, so we can delete this pod using the bleow command:
- ![image](https://github.com/user-attachments/assets/d86ae7ca-a990-4776-b78e-e1d81e2cf6b4)
  


- In Declarative way we do the deployment
  ![image](https://github.com/user-attachments/assets/ec8f8723-b058-438b-bb02-0fb9688312ef)

  Here it created pod and also replicaset


![image](https://github.com/user-attachments/assets/a208b4f3-967d-4e61-bef1-2bf10285a7f5)


- We can edit the deployment file by giving the command <b>kubectl edit deployment nginx-depl </b>    ---> here nginx-depl is deployment[ name]

  ![image](https://github.com/user-attachments/assets/40e71a6d-d579-4853-b0a7-df897044651e)

  - Once I edit deployment manifest  the  and increase replica count to 2 and save, it automatically create an additional pod
  - ![image](https://github.com/user-attachments/assets/873d8e15-d2e7-4b73-ba4d-7361bfe4fadb)
 
  - Checking the log of the pod   -> kubectl logs [pod's Name]
 
  ## Deploy example for Mongo and troubleshooting
    - kubectl create deployment mongo-depl --image=mongo   ->  this will create mongo deployment
    - kubectl get pod    -> this display a pod with pod name
    - kubectl describ pod [Pod Name]   -> this will give detail about the selected pod.

![image](https://github.com/user-attachments/assets/5ab85a5e-a42e-4560-8135-52db295b3925)

- Event part of the describ result give the step by step pod creation and status.

-We can also execute a pod in interactive terminal using the follwing command
    <b>kubectl exec <Pod's Name> -it sh  </b>
    * I can listdown all files using <b>ls</b> command
    * I can check databases using <b>show dbs</b> command


    - To remove all the deployment we can remove the deployment it will remove all the fies under it
        * kubectl get all
        * kubectl  get deployment
        * kubectl delete deployment <Deployment Name>
  

## Declarative Way of   running Kubernetes

- In declarative way we use yml file to create kubernetes and pods
- ex:
      * kubectl create -f [samepl.yml]
      * kubectl apply - [sample.yml]  - if file name exist it will updating or creating
      * kubctl describe   -> for truoble shooting
      * kubectl exec  -> for creating interactive terminal
      * kubectl delete -f [sample.yml]
 
 - ### Creating Nginx deployment using yml file Declarative way
   
   ![image](https://github.com/user-attachments/assets/bd639e9d-9b0a-4d5c-ae1b-3bad5760f54b)

![image](https://github.com/user-attachments/assets/31f3db92-1bfc-4b9f-9cfa-c72489730632)

![image](https://github.com/user-attachments/assets/4b11590f-027d-4d6f-b9a7-858d9ea08491)


-If I change anything in the yml file, ex. I increase the replica by one and now replicats is 2 so I need to rerun the same command

     <pre>kubectl apply -f .\nginx-depl.yml</pre>

![image](https://github.com/user-attachments/assets/d74afa7c-5ad4-4562-aca8-8c5ce8e7e711)

![image](https://github.com/user-attachments/assets/5767f136-ac60-432f-a666-dadf92a95373)


## Create Service in Kubernetes

Purpose of the Service is to provide a stable, network-accessible endpoints for a group of pods(Which all perform the same functions) by abstracting away the ephemeral nature of pod IP addresses and anabling load balancing and service discovery.

  - <b>Abstraction of Pods: </b> Kubernetes service act as a logical abstraction, grouoping a set of Pods (which all perform the same function)  into a single resource. <br/>
  - <b>Stable IP Address:</b> Each service is assigned a stable IP address and DNS name, which remain consistent regardless of the lifecyclr changes of the underlying pods.<br/>
  - <b>Service Discovery:</b> Clients can use the Service's IP address or DNS name to access the Pods within the Service, without needing to know the specific IP addresses of the individual Pods. <br/>
  - <b>Load Balancing :</b> Services can be configured to distribute traffic across multiple Pods, ensuring high availability and performance.  <br/>
  - <b>Network Exposure: <br/> Services are used to expose network applications that are running as one or more Pods in your cluster  <br/>
  
<b>Notes:</b> <br/>
    - In the deployment we can have separate yaml file one for Deployment yaml file and another for service yaml file or we can have a soingle file for deployment and service.<br/>
    - We specify 2 section in the deployment yaml file after deployment Kubernetes added antoher section called "Status"
       > <b>kubectl gt deployment [Deployment Name in our case Nginx-depl] -o yaml</b> will give the follwong output : <br/>
       ![image](https://github.com/user-attachments/assets/6de27e21-0ba9-44cb-9dbc-80fba737faf7)
       ![image](https://github.com/user-attachments/assets/a49b8939-84a1-4137-ae30-10932b9b0ef5)

       
<p>
  Deployment file and Service file <b>Label</b> is the importent thing. Kubernetes use label as the common name during the communication. It matching the resources using lable name.
  
</p>

### Creating Nginx service using yml file Declarative way
       
   - First we changed deployment yaml file port to 8080 becuase we are going to use port 80n for service.
   - ![image](https://github.com/user-attachments/assets/7d94db43-40a4-4989-9841-68f32e9ebb09)

     Then
     <b>kubectl apply -f .\nginx-depl.yml</b> <br/>
     then
     <b> kubctl apply -f .\nginx-service.yml

     Here the label for both deployment and service is ngonx and we said targetPort is 8080 so service match the deployment file using lable and targetport configuration.

     ![image](https://github.com/user-attachments/assets/42a86e6b-89be-44b8-91f7-0ddd93a0faad)

     ![image](https://github.com/user-attachments/assets/6851857a-bc1c-4f12-a9e4-f2b4437a8144)

     If we run kubectl get pod -o wide, we get extra details about the pode
     If you noticed, service IP-Addresses and the Pods IP addresses are matched.
     ![image](https://github.com/user-attachments/assets/48d55fc9-65cf-42e9-9a1e-3936e3a21f0e)
      

## Kubernetes Dashboard

https://github.com/kubernetes/dashboard

Now days Kubernetes installation support only Heml installation, So install Helm before install Kubernetes dashboad from this url https://helm.sh/docs/intro/install/
- Download Kelm zip file extract it in a directory and add that directory in the environment variable.

### Install Kubernetes dashboad using helm command
  
1. <b>Add kubernetes-dashboard repository</b><br/>
helm repo add kubernetes-dashboard https://kubernetes.github.io/dashboard/

2. <b>Deploy a Helm Release named "kubernetes-dashboard" using the kubernetes-dashboard chart</b><br/>
helm upgrade --install kubernetes-dashboard kubernetes-dashboard/kubernetes-dashboard --create-namespace --namespace kubernetes-dashboard



![image](https://github.com/user-attachments/assets/ab84fae4-4656-47cd-b848-3a7d8e2caad1)

Now we can use Port-Forward and run the Kubernetes dashboad using the following command
<pre>
  kubectl -n kubernetes-dashboard port-forward svc/kubernetes-dashboard-kong-proxy 8443:443
</pre>


Now we need to create a service account and for that we need to create Bearer token to access Dashboad

![image](https://github.com/user-attachments/assets/0ea01b8f-f254-4344-9fe1-b210a62da4d8)


# Dashboad deploy using Kubectl : 
kubectl apply -f https://raw.githubusercontent.com/kubernetes/dashboard/v2.6.0/aio/deploy/recommended.yaml

Use this command to get the bearer token :<br/>
<b>kubectl describe secret -n kube-system</b> <br/>
here kude-system is the namespace to get all namespaces run <b>kubectl get namespace</b> <br/>

- To access the dash board using proxy use the command<br/>
<b>kubectl proxy </b>
this will give us a url to browse the dashboad.<br/>
Open the dashboard using this url <br/>

<b>http://localhost:8001/api/v1/namespaces/kubernetes-dashboard/services/https:kubernetes-dashboard:/proxy/#/login</b>
Now enter the bearer token and login.



## Visual Studio setup

- Extension to install
    * Docker
    * Kubernestes (Microsoft)
    * YAML (redhat)
 
  And then We create Yaml file that contains both Deployment and service.
  - One thing we need to notice here is, we may use sensitive data like username and password, we are going to create a separate yaml file to hold all these sensitive data.
  - File we create for secret, Data should be in base 64 format so we need to convert the sensitive data to base64 data
  - We can use <b>https://www.base64encode.org/ </b> site to convert normal string to base64 staring <br/>
  - ex. username = username   ---> username = dXNlcm5hbWU=   <br/>
        password= password    ----> password =  cGFzc3dvcmQ=  <br/>

  Kubernetes should know the secret before it create any deployment or services that gooing to use the secret so we need to apply the secret before we appl deployment or service.
  <b>Note : </b> Some time if default namespace not got set all namespace realted kubectl command will fail. so we need to set the default namespece using following commands
  <pre>
    kubectl get namespace
    kubectl config set-context --current --namespace=kube-system 
  </pre>

### Deployment yaml
<pre>
apiVersion: apps/v1
kind: Deployment
metadata:
  name: mongo-deployment
  labels:
    app: mongodb
spec:
  replicas: 1
  selector:
    matchLabels:
      app: mongodb
  template:
    metadata:
      labels:
        app: mongodb
    spec:
      containers:
      - name: mongodb
        image: mongo
        ports:
        - containerPort: 27017
        resources:
          requests:
            memory: "64Mi"
            cpu: "250m"
          limits:
            memory: "128Mi"
            cpu: "500m"
        env:
        - name: MONGO_INITDB_ROOT_USERNAME
          value: fdsfsf
        - name: MONGO_INITDB_ROOT_PASSWORD
          value: fdsfds

</pre>
 ### secret yaml
 <pre>
    apiVersion: v1
    kind: Secret
    metadata:
      name: mongo-secret
    type: Opaque
    data:
      mongo-root-username: dXNlcm5hbWU=
      mongo-root-password: cGFzc3dvcmQ=

 </pre>
  so we need to apply secret now:
  ![image](https://github.com/user-attachments/assets/e399ad49-4924-4572-aa1c-767ca8241abc)
  

  Now we need to map the secret to the deployment yaml file so that deployment will know the username and password.
  This is the modified mongo.yaml file which refers the username and password from secret
  <pre>
    apiVersion: apps/v1
    kind: Deployment
    metadata:
      name: mongo-deployment
      labels:
        app: mongodb
    spec:
      replicas: 1
      selector:
        matchLabels:
          app: mongodb
      template:
        metadata:
          labels:
            app: mongodb
        spec:
          containers:
          - name: mongodb
            image: mongo
            ports:
            - containerPort: 27017
            resources:
              requests:
                memory: "64Mi"
                cpu: "250m"
              limits:
                memory: "500Mi"
                cpu: "500m"
            env:
            - name: MONGO_INITDB_ROOT_USERNAME
              valueFrom:
                secretKeyRef:
                  name: mongo-secret
                  key: mongo-root-username
            - name: MONGO_INITDB_ROOT_PASSWORD
              valueFrom:
                secretKeyRef:
                  name: mongo-secret
                  key: mongo-root-password



  </pre>

- Now we can apply the changes by running below command:
![image](https://github.com/user-attachments/assets/81a96747-0ca5-48e0-b173-0e91796744c2)


- We can increse the replca count directly from kubectl command without changing the yaml file:
<pre>
  kubectl scale replicaset |replicaName| --replicas=5
</pre>


![image](https://github.com/user-attachments/assets/1020f019-a3e9-4562-9975-681e57f3796a)

## Adding service definition

We can add the service definition for the mongo db within the same yaml file, we need to put <b>---</b> to separate the definitions.
Yaml file with deployment and service is as follows:
<pre>
      apiVersion: apps/v1
    kind: Deployment
    metadata:
      name: mongo-deployment
      labels:
        app: mongodb
    spec:
      replicas: 1
      selector:
        matchLabels:
          app: mongodb
      template:
        metadata:
          labels:
            app: mongodb
        spec:
          containers:
          - name: mongodb
            image: mongo
            ports:
            - containerPort: 27017
            resources:
              requests:
                memory: "64Mi"
                cpu: "250m"
              limits:
                memory: "500Mi"
                cpu: "500m"
            env:
            - name: MONGO_INITDB_ROOT_USERNAME
              valueFrom:
                secretKeyRef:
                  name: mongo-secret
                  key: mongo-root-username
            - name: MONGO_INITDB_ROOT_PASSWORD
              valueFrom:
                secretKeyRef:
                  name: mongo-secret
                  key: mongo-root-password
    ---
    apiVersion: v1
    kind: Service
    metadata:
      name: mongo-service
    spec:
      selector:
        app: mongodb
      ports:
      - protocol: TCP
        port: 27017
        targetPort: 27017
</pre>

Once agian run the kubectl apply command will create the service.

![image](https://github.com/user-attachments/assets/8612d207-ddcd-457f-b0d1-44905fa6f8f5)


## How service get end-point of a POD  and when Pod getting deleted how end=point getting updated?
<img width="1024" height="1024" alt="image" src="https://github.com/user-attachments/assets/130515d9-cc9e-4861-9eef-95902ff57a92" />


To get the service end point we can run kubectl describe service [serviceName]  --> here service name is mongo-service.

![image](https://github.com/user-attachments/assets/a2619f4d-f7aa-451e-a2e1-6c7ff96499e2)


![image](https://github.com/user-attachments/assets/fae08480-fd59-4d5d-ab87-487d66311046)



## Pushing docker Shopping images to dockerHub

- run <b> docker-compose -f .\docker-compose.yml -f .\docker-compose.override.yml up -d </b> under shopping folder, this will create ShoppingApi, ShoppingClient  and shoppingdb images.
- ![image](https://github.com/user-attachments/assets/afaa726c-7e8c-45a5-9271-baf2faa3944c)

- Tage the image using following command
- ![image](https://github.com/user-attachments/assets/190d32ba-af3e-44c9-b45d-da30e7f3d4c5)
- This will tage existing image with our docker repository path and now we are ready to push the image before that we can change the image list
- ![image](https://github.com/user-attachments/assets/2a16c2a2-4be5-4fe0-997f-00c0cb5dbdaa)
- Create two repositories in the dockerhub
     * shoppingclient
     * shoppingapi
- Push the images to dockerhub
   ![image](https://github.com/user-attachments/assets/8682123d-fcc5-4795-ad6d-cda1552da481)

- Now we can check the docker hub
     ![image](https://github.com/user-attachments/assets/27adf03c-a911-4ff9-b012-1a1ea62c2da6)

  ![image](https://github.com/user-attachments/assets/ea10237f-f959-4c24-95f5-000246088ff9)

 ![image](https://github.com/user-attachments/assets/ec0d33f1-3f11-43bf-ac76-c67ef42381be)

  
- Now we can delete the docker container and images because we are not going to use docker contaimner, we already push Images to dockerhub.
- so ruun <b>docker-compose -f .\docker-compose.yml -f .\docker-compose.override.yml down</b>  command this will  delete ShoppingClient and ShoppingApi containers.

### Create ShoppingApi Deployment yaml file
<pre>
apiVersion: apps/v1
kind: Deployment
metadata:
  name: shoppingapi-deployment
  labels:
    app: shoppingapi
spec:
  replicas: 1
  selector:
    matchLabels:
      app: shoppingapi
  template:
    metadata:
      labels:
        app: shoppingapi
    spec:
      containers:
      - name: shoppingapi
        image: newmancroos/shoppingapi:latest
        imagePullPolicy: IfNotPresent
        ports:
        - containerPort: 8080
        env:
        - name: ASPNETCORE_ENVIRONMENT
          value: Development
        - name: DatabaseSettings__ConnectionStaring
          value: mongodb://username:password@mongo-service:27017
        resources:
          requests:
            memory: "64Mi"
            cpu: "250m"
          limits:
            memory: "500Mi"
            cpu: "500m"
---

apiVersion: v1
kind: Service
metadata:
  name: shoppingapi-service
spec:
  type: NodePort
  selector:
    app: shoppingapi
  ports:
  - protocol: TCP
    port: 8000
    targetPort: 8080
    nodePort: 31000
</pre>



   - What is NodePort?
      If you notice in the above yaml file we specify service: spect: type = NodePort and we assigned 31000 for the nodePort.
     
     ![image](https://github.com/user-attachments/assets/174aca73-a4ff-49f0-bae2-42888d3b1cca)

     Normally we use Spect type : NodePort only for development purpose, we can call the service from our local machine but in the production environment we should use <b>Load Balancer or Cluster IP</b> so it is accessable within Kubernetes but development purpose we need to test it from local computer so we use NodePort.


Now we can apply changes for shoppingapi.yaml

![image](https://github.com/user-attachments/assets/854a559a-efc6-4f2d-97ff-301cb1a9ea76)

![image](https://github.com/user-attachments/assets/c4eed139-06be-45f3-abab-01d30a7b9402)

Shoppingapi is running and exposing 31000 so we can browse it in <b>http://localhost:31000</b>

![image](https://github.com/user-attachments/assets/b771f31d-2fbd-4879-9ac9-33d132749972)



- Note that in the shoppingapi yaml file we have specified the usernam and password fo the cosmos database in the connection string but it is not a good practice, so we need to move it to Config map of the kubernetes.

### Config map yaml

First we create <b>mongo-configmap.yaml</b> file with the following content
<pre>
  apiVersion: v1
kind: ConfigMap
metadata:
  name: mango-configmap
data:
  connection_string: mongodb://username:password@mongo-service:27017
</pre>
     
And modify the <shoppingapi.yaml</b> as below
<pre>
    apiVersion: apps/v1
    kind: Deployment
    metadata:
      name: shoppingapi-deployment
      labels:
        app: shoppingapi
    spec:
      replicas: 1
      selector:
        matchLabels:
          app: shoppingapi
      template:
        metadata:
          labels:
            app: shoppingapi
        spec:
          containers:
          - name: shoppingapi
            image: newmancroos/shoppingapi:latest
            imagePullPolicy: IfNotPresent
            ports:
            - containerPort: 8080
            env:
            - name: ASPNETCORE_ENVIRONMENT
              value: Development
            - name: DatabaseSettings__ConnectionStaring
              valueFrom:
                configMapKeyRef:
                  name: mongo-configmap
                  key: connection_string
            resources:
              requests:
                memory: "64Mi"
                cpu: "250m"
              limits:
                memory: "500Mi"
                cpu: "500m"
    ---
    
    apiVersion: v1
    kind: Service
    metadata:
      name: shoppingapi-service
    spec:
      type: NodePort
      selector:
        app: shoppingapi
      ports:
      - protocol: TCP
        port: 8000
        targetPort: 8080
        nodePort: 31000
</pre>

![image](https://github.com/user-attachments/assets/51579a59-010b-4ef1-b78a-c0fce8557f97)

Now we can apply configmap and shoppingapi yaml

![image](https://github.com/user-attachments/assets/b65c1982-db8f-4982-b46a-375bc792a86f)


![image](https://github.com/user-attachments/assets/1183dcc7-1a5f-4f51-ba77-b8e4458c8bc2)



## Create ShoppingClient Deployment yaml file

Shopping client uses shoppingapi url, so we create shoppingapi configMap first before creating shoppngclient deployment/service yaml

<pre>
  apiVersion: v1
  kind: ConfigMap
  metadata:
    name: shoppingapi-configmap
  data:
    shoppingapi-url: http://shoppingapi-service
</pre>

Now apply this changes using the following command<br/>
<b>kubectl apply -f .\shoppingapi-configmap.yaml</b><br/>

- Now shoppingclient.yaml as follows
  <pre>
  apiVersion: apps/v1
  kind: Deployment
  metadata:
    name: shoppingclient-deployment
    labels:
      app: shoppingclient
  spec:
    replicas: 1
    selector:
      matchLabels:
        app: shoppingclient
    template:
      metadata:
        labels:
          app: shoppingclient
      spec:
        containers:
        - name: shoppingclient
          image: newmancroos/shoppingclient:latest
          imagePullPolicy: IfNotPresent
          ports:
          - containerPort: 8080
          env:
          - name: ASPNETCORE_ENVIRONMENT
            value: Development
          - name: ShoppingAPIUrl
            valueFrom:
              configMapKeyRef:
                name: shoppingapi-configmap
                key: shoppingapi-url
          resources:
            requests:
              memory: "64Mi"
              cpu: "250m"
            limits:
              memory: "500Mi"
              cpu: "500m"
  ---
  
  apiVersion: v1
  kind: Service
  metadata:
    name: shoppingclient-service
  spec:
    type: LoadBalancer
    selector:
      app: shoppingclient
    ports:
    - protocol: TCP
      port: 8001
      targetPort: 8080
      nodePort: 30000
  </pre>

- Run <b> kubectl apply -f .\shoppingclient.yaml</b>

![image](https://github.com/user-attachments/assets/55fe2681-dd90-408a-a515-8e1e219531f4)

- Now when browsing localhost:30000 page not doisplayed.

  ![image](https://github.com/user-attachments/assets/ffaeac4f-2844-4c7e-b716-5947da9417e6)

  ## Trubleshooting:
  
 - First we check the Shoppingclient pod with <b>kubectl get pod <shoppingclientpodname> -o wide

   ![image](https://github.com/user-attachments/assets/425ec8d5-87f4-4c2a-a7a7-58719d0646bf)

   We don't find any problem here

- Check the log of the shoppingclient pod

  ![image](https://github.com/user-attachments/assets/ce8573f8-0116-4455-af9f-5b639ac4458e)

  Here also we don;t find any problem

  - Sice we are working on local machine Service type : <b>LoadBalancer</b> might noe work because we don;t have any LoadBalancer configuration. So lets change this to <b>NodePort</b> and try

    ![image](https://github.com/user-attachments/assets/b0df0ea9-29a0-4e53-a7ae-607999ac4c2e)

  *** Now we get the exception page when we brows to <b>http://localhost:30000</b>

  ![image](https://github.com/user-attachments/assets/184c4b91-c45d-4adb-bda8-2df22f854867)


  - In <b>shoppingapi-Configmap.yaml</b> we didn't specify any port number
 
    ![image](https://github.com/user-attachments/assets/0db8feab-f6c8-41be-85bd-8b80c6115835)

    So it is default taking <b>8080</b> but inside the kubernetes we expose it to <b>8000 </b>

    So we need to change  <b>shoppingapi-Configmap.yaml</b> shoppingapi-url as below

    ![image](https://github.com/user-attachments/assets/ddde415e-2a00-4046-8ec2-c88066f672ac)
    

![image](https://github.com/user-attachments/assets/3900619f-3d99-49db-bffb-c8f338518b7c)

Now it is working fine.


![image](https://github.com/user-attachments/assets/84a95a0b-6caa-4f48-b155-0cf8fcc9d411)





Everything working foine so we can delete all respource so that we can release the CPU memory

![image](https://github.com/user-attachments/assets/77db336c-f9c7-455f-9d47-a10b1c3a8191)




## Azure Container Registery (ACR)

![image](https://github.com/user-attachments/assets/2b547fd4-ed5b-4162-873a-ea96b60fb00d)


![image](https://github.com/user-attachments/assets/f6893014-d3bb-4909-8b1f-52aba685440c)


## Azure Kubernetes Service (AKS)

- Deploye a managed kubernetes
- Reduces the complexcity and operational overhead
- Azure handles critical tasks
- maintenance for you
- Free plan


##Notes:
  - To get the kubernestes context we can use the following commands: <br>
     * kubectl config get-context  --> Get all context<br/>  
     * kubectl config current-context ---> Get current context <br/>
     * kubectl config use-context [ContextName] --> Switch to a context  <br/>
   

## Preparing files to deploy to Azure Kubernetes

<b>Step1 : Creating the container Images</b>
<pre>docker-compose -f .\docker-compose.yml -f .\docker-compose.override.yml up -d</pre>

   * This step is to create image, so after testing we can down the containers using
     <pre>docker-compose -f .\docker-compose.yml -f .\docker-compose.override.yml down</pre>

<b>Step2 :</b>
 - We can use Azure portal to push images to Azure container registry and then deplpoy it to Kubernetes cluster OR
    We can use Command line interface (CLI). We can install local intsalltion of Azure CLI (.
   version >2.1) <br/>
   https://learn.microsoft.com/en-us/cli/azure/install-azure-cli-windows?pivots=winget
<br/>
If it is correctly installed
<pre>
  az --version
</pre>
Will return the result <br/>

<b>Step3:</b><br/>
Logion into azure
<pre>az login</pre>

<b>Step4:</b> <br/>
 - Create resource group so that we can put all the related resources into this resource group
<pre>
  az group create --name myResourceGroup --location westeurope
</pre>

![image](https://github.com/user-attachments/assets/40d41a8c-1d5a-47e5-a5a6-a85cb196f354)

<b>Step5:</b><br/>
We are going to create <b>Azure Container Registry inside the Resource group we created</b>
<pre>
  az acr create --resource-group myResourceGroup  --name shoppingnewmanacr --sku Basic
</pre>
here sku is Conception model

![image](https://github.com/user-attachments/assets/6cc4a5ee-6283-4051-829d-ca55370e84cc)

<b>Step6:</b><br/>
Before pushing the image we need to enable <b>admin Account</b>. Each container registry is contains one admin account but by default it is disabled.<br/>
We need admin account to deploy container image from portal. Admin account will have full access so it is easy to push images and create containers in Azure Kubernetes.

<pre>
  az acr update -n shoppingnewmanacr --admin-enabled true
</pre>

We can also enable it using portal

![image](https://github.com/user-attachments/assets/c03f8a26-34dc-4c42-aba1-1bd2191f7bc7)


After execute az acr update command, admin user got enabled.

![image](https://github.com/user-attachments/assets/fef8353a-e19e-486b-a692-a54cc9651473)


<b>Step 7: Login to acr</b><br/>
<pre>az acr login --name shoppingnewmanacr</pre>

![image](https://github.com/user-attachments/assets/13bbaf0c-26d6-44fb-b0e7-d35655c792fa)

<b>Step 8: Before push image to ACR Tag the Images</b><br/>
- Before push the images to ACR we need to tag with login server address of our ACR. <br/>
- How to get login server address? <br/>
   <pre>az acr list --resource-group myResourceGroup --query "[].{acrLoginServer:loginServer}" --output table</pre>

   ![image](https://github.com/user-attachments/assets/bf762dac-707b-47cd-86fd-14e7750a6445)

  In our case Login server address is <b>shoppingnewmanacr.azurecr.io</b> <br/>

  Now we can tag our image with Login server address <br/>

  <pre>
    docker tag shoppingapi:latest shoppingnewmanacr.azurecr.io/shoppingapi:v1
    docker tag shoppingclient:latest shoppingnewmanacr.azurecr.io/shoppingclient:v1
  </pre>


![image](https://github.com/user-attachments/assets/9668e42b-6e61-41cc-8e0f-cb3ce6e7024a)

<b>Step 9: Push image to ACR</b><br/>
It is the same command as Docker push to Dockerhub<br/>
<pre>
  docker push shoppingnewmanacr.azurecr.io/shoppingapi:v1
  docker push shoppingnewmanacr.azurecr.io/shoppingclient:v1
</pre>
List the repositories as list:
<pre>
  az acr repository list --name shoppingnewmanacr --output table
</pre>
![image](https://github.com/user-attachments/assets/be0f0433-6845-47a5-865e-12638d7594d4)

Display the Tags:
<pre>
  az acr repository show-tags --name shoppingnewmanacr --repository shoppingclient --output table
  az acr repository show-tags --name shoppingnewmanacr --repository shoppingapi --output table
</pre>

![image](https://github.com/user-attachments/assets/62f64080-558e-4358-bb82-b8fa202beba1)

![image](https://github.com/user-attachments/assets/cb531e66-6008-44b5-b9b9-6db020a24c34)

<b>Step 10: Create Azure Kubernetes Cluster</b><br/>

<pre>az aks create --resource-group myResourceGroup --name myAksCluster --node-count 1 --generate-ssh-keys --attach-acr shoppingnewmanacr</pre>

Here we create Aks cluster and attach shoppingnewmanacr so that it can pull images from the ACR.

<b>Note:</b>
If you get "MissingSubscriptionRegistration" error run
<pre>
  az provider register --namespace Microsoft.ContainerService
</pre>
and then run 
<pre>
  az aks create --resource-group myResourceGroup --name myAksCluster --node-count 1 --generate-ssh-keys --attach-acr shoppingnewmanacr
</pre>

<b>Step 11:Connect Kubernetes cliuster to the local computer</b><br/>
To run kubectlcommand against azure kubernetes we need to install <b>Azure aks cli</b>
<pre>
  az aks install-cli
</pre>

![image](https://github.com/user-attachments/assets/48fae45f-b34e-4c2c-8a58-bc22966b1586)

- Now we need to connect the Cluster using <b>kubectl</b> <br/>
Inorder to configure kubectl  to connect your kubernetes cluster, we use
<pre>
az aks get-credentials --resource-group myResourceGroup --name myAKSCluster
</pre>

![image](https://github.com/user-attachments/assets/bae10952-1c11-41cb-8cce-1c38766a9220)

- To verify the connection to the Cluster we can check using this below command:
  <pre>
    kubectl get all
  </pre>
![image](https://github.com/user-attachments/assets/7f645758-f858-42c3-82f3-1acd250eb646)

<pre>
kubectl get nodes
</pre>

![image](https://github.com/user-attachments/assets/9e8f4f8d-865f-427a-96b3-73e816c1a9d5)

<b>Step 12:Run application in Azure Kubernetes Services</b><br/>
1. Update Kubernetes manifest yaml file
2. Tun the application
3. Test Application

- Update Kubernetes manifest file with <b>login server name <b>shoppingnewmanacr.azurecr.io</b>
- We need to update the image repository in shoppingapi.yaml and shoppingclient.yaml as per azure kubernetes repository. <br/>
We now have the dockerhub repository configuration in the k8s folder we need to move it to aks folder and change the configuration<br/>
- Listing repository
  <pre>
    az acr repository list --name shoppingnewmanacr --output table
  </pre>
  ![image](https://github.com/user-attachments/assets/7b3b0717-09af-4f42-9277-8785768a78c6)

<b>Step 13:Create Image pull secret for ACR container</b><br/>
In order to create pull secret we need to provide <b>Service principal Id and registry url</b> <br/>
1. Get login server name:
<pre>
  az acr list --resource-group myResourceGroup --query "[].{acrLoginServer:loginServer}" --output table
</pre>
![image](https://github.com/user-attachments/assets/18e53481-51f5-4917-98cf-6daba40df6a4)

2. Collect ACR User name and Password from the portal
![image](https://github.com/user-attachments/assets/76ebbd98-5f66-4e81-a9d5-a54dde0c8984)

In My case <br/>
<b>User Name: shoppingnewmanacr</b>  <br/>
<b>Password : 3FAHb78RisMLdRw2If4Sm8pZQV8+T6etpLfLuzkvq2+ACRDafvb6 </b> <br/>

3. Create Secret
   <pre>
     kubectl create secret docker-registry acr-secret --docker-server=shoppingnewmanacr.azurecr.io --docker-username=shoppingnewmanacr --docker-password=3FAHb78RisMLdRw2If4Sm8pZQV8+T6etpLfLuzkvq2+ACRDafvb6 --docker-email=croosnewman@gmail.com
   </pre>
![image](https://github.com/user-attachments/assets/69b84a38-7446-49b9-ac05-94b00935822a)

<b>Step 14:Modify the deployment file</b><br/>
- Copy all k8s file to aks folder
- We change shoppingapi.yaml and shoppingclient.yaml and change Image and imagePullSecret as follows:
- Change are in <b>Deployment section for adding image name and imagePullSecret </b> and <b>in Service section to change local Kubernetes setting to clude Kubernetes, We use NodePort for local setting</b>
- We remove Type, Noreport and target port
  
  <u>shoppingapi.yaml</u>
  <pre>
  apiVersion: apps/v1
kind: Deployment
metadata:
  name: shoppingapi-deployment
  labels:
    app: shoppingapi
spec:
  replicas: 1
  selector:
    matchLabels:
      app: shoppingapi
  template:
    metadata:
      labels:
        app: shoppingapi
    spec:
      containers:
      - name: shoppingapi
        image: shoppingnewmanacr.azurecr.io/shoppingapi:v1
        imagePullPolicy: IfNotPresent
        ports:
        - containerPort: 8080
        env:
        - name: ASPNETCORE_ENVIRONMENT
          value: Development
        - name: DatabaseSettings__ConnectionStaring
          valueFrom:
            configMapKeyRef:
              name: mongo-configmap
              key: connection_string
        resources:
          requests:
            memory: "64Mi"
            cpu: "250m"
          limits:
            memory: "500Mi"
            cpu: "500m"
      imagePullSecrets:
      - name: acr-secret
---

apiVersion: v1
kind: Service
metadata:
  name: shoppingapi-service
spec:
  selector:
    app: shoppingapi
  ports:
  - protocol: TCP
    port: 8080
</pre>

<u>shoppingcliant.yaml</u>

- We use shoppingapi url in shoppingcloient using shoppingapi-configmap.yaml, so before we change shoppingclient.yaml shopping-configmap.yaml
- Here we removed port for the shopping-service
<pre>
  apiVersion: v1
  kind: ConfigMap
  metadata:
    name: shoppingapi-configmap
  data:
    shoppingapi-url: http://shoppingapi-service
</pre>

<pre>
 apiVersion: apps/v1
kind: Deployment
metadata:
  name: shoppingclient-deployment
  labels:
    app: shoppingclient
spec:
  replicas: 1
  selector:
    matchLabels:
      app: shoppingclient
  template:
    metadata:
      labels:
        app: shoppingclient
    spec:
      containers:
      - name: shoppingclient
        image: shoppingnewmanacr.azurecr.io/shoppingclient:v1
        imagePullPolicy: IfNotPresent
        ports:
        - containerPort: 8080
        env:
        - name: ASPNETCORE_ENVIRONMENT
          value: Development
        - name: ShoppingAPIUrl
          valueFrom:
            configMapKeyRef:
              name: shoppingapi-configmap
              key: shoppingapi-url
        resources:
          requests:
            memory: "64Mi"
            cpu: "250m"
          limits:
            memory: "500Mi"
            cpu: "500m"
      imagePullSecrets:
      - name: acr-secret
---

apiVersion: v1
kind: Service
metadata:
  name: shoppingclient-service
spec:
  type: LoadBalancer
  selector:
    app: shoppingclient
  ports:
  - protocol: TCP
    port: 8080
</pre>

- Get Rreplica set, Gives number of replicaa and Disire/Current/Ready/Age status:
  <pre>
    kubectl get rs
  </pre>
- Check the current context
![image](https://github.com/user-attachments/assets/820f2dbd-a872-47a0-9c95-68dbfd27b834)

- If we have more than one context we can use
  <pre>
    kubectl config use-context [ContextName]
  </pre>
  
- Now weneed to run all yaml file in the aks cluster
  ![image](https://github.com/user-attachments/assets/8443f7a0-7c66-490a-9012-3447f6ecf02c)

  Here we are running all files in the aks doirectory<br/>

  Noew <b>kubectl get all</b> returns the following recoreces

  ![image](https://github.com/user-attachments/assets/41c6ba2d-4b00-44d2-b1d4-5c8f688e1a58)

  - Now if we get service details by running <b> kubectl get svc</b> we'll bget service details with external ip address:
    ![image](https://github.com/user-attachments/assets/d674061d-c5e6-4040-ab46-735cd8c67238)



  ## Type of services in Kubernetes

  - There are two types of servoce
      * Cluster Ip Server - We can communicate within cluster that means within Pods or between more Pods in the same cliuster. 
         <img width="595" height="392" alt="image" src="https://github.com/user-attachments/assets/1ae29ccd-3763-48b3-8c56-bf21b5eb79b5" />

         Here Java applicationa and MySql will have Cluster Ip

        

