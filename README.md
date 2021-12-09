# Multi Container Application orchestration using Docker Compose.
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





 
