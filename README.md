# Multi Container Application orchestration using Docker Compose.
Traditionally most of the Enterprise applications are divided into different layers for abstraction. We generally see the following tiers in a traditional application.
1. Web/Presentation Layer - This is typically the front end developed using Angular/React/MVC using Razor etc
2. API/Business Layer -     This is where the business logic of the application resides and also involves calling a webservice/database layer.
3. Data/Repository Layer -  This layer generally contains the logic to connect/perform the CRUD operations on the database. 

In the monolithic world all the 3 layers generally used to reside in the same solution and generally considered as a single unit of deployment. With the advent of Microserives 
these 3 layers will be delivered as 3 independent Microservices which can be developed using different technologies. In the monolithic world, the technical stack can be developed 
entire using Microsoft stack using ASP.NET MVC for Web Tier, ASP.NET Web API for API layer and SQL Server for database layer. However, in Microservices world Web Tier can be developr
using Angular/React and API layer can be developed using Node.JS and database layer can be either a traditional RDBMS like SQL Server/Oracle or can be a NoSQL DB like MongoDB as well.
Also in addition to this,   we can have additional layers like Caching as well. 
