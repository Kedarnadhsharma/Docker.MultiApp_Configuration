# Multi Container Application orchestration using Docker Compose
Traditionally most of the Enterprise applications are divided into different layers for abstraction. We generally see the following tiers in a traditional application.
1. Web/Presentation Layer - This is typically the front end developed using Angular/React/MVC using Razor etc
2. API/Business Layer -     This is where the business logic of the application resides and also involves calling a webservice/database layer.
3. Data/Repository Layer -  This layer generally contains the logic to connect/perform the CRUD operations on the database. 

In the monolithic world all the 3 layers generally used to reside in the same solution and generally considered as a single unit of deployment. With the advent of Microserives 
these 3 layers will be delivered as 3 independent Microservices which can be developed using different technologies. 

In the monolithic world, all the 3 tiers are generally developed using Microsoft stack using ASP.NET MVC for Web Tier, ASP.NET Web API for API layer and SQL Server for database layer. However, in Microservices world Web Tier can be developed using Angular/React, API layer can be developed using Node.JS and database layer can be either a traditional RDBMS like SQL Server/Oracle or can be a NoSQL DB like MongoDB as well. We can also have additional layers like Caching/Reverse Proxy/Domain layers depending on the application complexity.  

Considering, the heterogeneous nature of the different tiers, each tier will be developed as a microservice and can be deployed using a single Docker Compose file.

1. In this article we are going to see a simple 3 tier application having Web/API & Database tiers. 


1. First we will start with the Web and API projects. Intially we will be loading a static list of values from the API. Later, we will change the implmenetation to get these values a SQL Server.  

2. The Solution contains 2 projects a Web project and a API Project as below

![image](https://user-images.githubusercontent.com/50028950/145346506-08c7ca1c-e880-4619-81a4-fb0fa518a18c.png)

3. For now the BookController from the API project picks a randomly selected book from a static list.

![image](https://user-images.githubusercontent.com/50028950/145346806-ca81e992-0555-42e3-9504-b045a698c90d.png)

4. API project runs under http:localhost:31895 and the Swagger details are like below.

![image](https://user-images.githubusercontent.com/50028950/145346887-250970cb-946c-4714-9827-ef7c5516372d.png)

![image](https://user-images.githubusercontent.com/50028950/145347071-fcaffeaf-3460-43ec-bd43-632a2044e0ea.png)


5. Now from the Web Project we make a call to the above API and display the result on the UI. The code snippet is as follows in Index.cshtml.cs & Index.cshtml

![image](https://user-images.githubusercontent.com/50028950/145347348-9f1edeac-a954-4c8e-9e14-d5224b964243.png)

![image](https://user-images.githubusercontent.com/50028950/145347468-171b1031-5496-4239-b4ea-ed50c365a57f.png)

6. The final result from the UI is given below. 

![image](https://user-images.githubusercontent.com/50028950/145347813-fa163ee3-dec9-49c8-b951-00af8d70069f.png)

# Adding Container support 
Now that our application is up and running we will add Docker Support for the application.
1. Right click the Web Project and Select Add -> Container Orchestrator Support and Select Docker Compose as the Container Orchestrator and Linux as the Target OS.2

![image](https://user-images.githubusercontent.com/50028950/145350338-f7ddadfc-efaa-4cf1-9eb4-52582817ce8d.png)

2. This will add the Docker Compose file and the dockerignore files to the solution as shown below. Currently the dockercompose file has only one service for the API. 

![image](https://user-images.githubusercontent.com/50028950/145350809-5cd6930d-d2f6-4a56-8614-111520161bf7.png)

3. Additionally VS 2019 has added a Docker file to the API project named "Dockerfile" and this will be used by the Docker Compose file while building.

![image](https://user-images.githubusercontent.com/50028950/145351505-45f83fe9-97a6-4d1d-b24f-4cfeb1d857b1.png)

5. Next we will add another service to the docker compose file which represents the Web. 
6. Right click the Web project and select Add-> Container Orchestration Support --> Select Docker Compose --> Select Linux as the OS. These steps are similar to step 1 we did for API project.
7. Visual studio adds a Docker file for the Web project and also updates the Docker compose file to include the Web as another service. 
8. Updated Docker Compose file & the Docker file for the Web project are as follows. 
  ![image](https://user-images.githubusercontent.com/50028950/145352149-3fd17d78-09f1-4cd6-b4cf-915122c67fab.png)


   ![image](https://user-images.githubusercontent.com/50028950/145351974-a71b072f-6d1c-4360-8a7a-98462a50259e.png)
   
 9. Also observe that as soon as we add the docker compose VS 2019 has changed the Debug option to docker-compose.
 
 ![image](https://user-images.githubusercontent.com/50028950/145351133-1a502780-27bf-40d3-92f7-534df9ba6d6c.png)
 







 
