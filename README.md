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
 
 10. I made a couple of changes to the Docker compose file to indicate the API to start first by using the depends_on and also added the port entries.
  ![image](https://user-images.githubusercontent.com/50028950/145380500-9082d3a1-ef72-4a4d-9d1d-ebde4ccf0c62.png) 

 12. Lets run the docker compose build and docker compose up commands to see whether the App is working or not.
  
 13. If you have Docker Desktop installed you can see both the containers up and running as below.
 
   ![image](https://user-images.githubusercontent.com/50028950/145381959-39b4614f-56e9-47b1-95e3-4be1d8af70ae.png)


  
 14. If you go to https:localhost:9000 you can see the same UI as before.
 
     ![image](https://user-images.githubusercontent.com/50028950/145380733-6ea64d06-03b0-498c-baa8-b9468bf2df3c.png)
    
 So we have successfully containerized our application now. Next step is to add a database layer and get the data from DB, rather than a static list from Repository.
 
 # Adding SQL Server to the Application and enhance Docker Compose to SQL Server  

 We are going to run a SQL Server as a container and also create a database and some sample data as well. 
 
 1. Create a folder called Database and add the following Database_Setup.sql file as follow. This SQL file creates a database called DockerAppDB and creates a table called 
    Book and inserts some data. 
    
    ![image](https://user-images.githubusercontent.com/50028950/145572375-edcea126-3b27-4459-9fc2-64f47f5d56c8.png)

2. Add a docker file to create a SQL Server container from the SQL Server Ubuntu image and runs a few SQL commands to run the above SQL file once the server is ready.
   ![image](https://user-images.githubusercontent.com/50028950/145572602-b1f07d19-529d-40d0-bc22-8937d6346b1b.png)
   
   import-data.sh
   
   ![image](https://user-images.githubusercontent.com/50028950/145572676-d5a3d93d-e4ad-4c6e-a15e-a4390c8adf5c.png)
   
   entrypoint.sh
   
   ![image](https://user-images.githubusercontent.com/50028950/145572744-9764226e-e5fb-4e4f-8c99-5847c1968da9.png)
   
   3. If you navigate to the Databasefolder under API project and build the Docker file, we can see the database created. We can connect to the same using sa and sapassword
   
   We can see the Books table with the sample data created using the Database_Setup.sql file.
   
   ![image](https://user-images.githubusercontent.com/50028950/145573299-f2ffa2da-a037-41c7-9ec4-7f7bc110ca90.png)


 These steps will make our SQL Server ready with some sample data. Now we need to connect from our API project to this SQL Server container and get the data.
 We will use EntityFrameworkCore to connect from API to the database.
 
 4. Add the following Nuget packages to the API project. 
 
 ![image](https://user-images.githubusercontent.com/50028950/145573544-25c1e728-6fe7-4583-83b5-a134aab2c755.png)
 
 5. Create a DBContext class as below  

  ![image](https://user-images.githubusercontent.com/50028950/145573625-854c4a2d-3dcc-4d72-aeb1-cfbaeeff7eda.png)
  
  6. Open the appsettings.json file and add the ConnectionStrings Settings with the sql server details
  
  ![image](https://user-images.githubusercontent.com/50028950/145573956-b84c6237-922c-49a9-908c-be7e311bd14f.png)
  
  7. Wire up the DBContext class as a service during the StartUp for the API.
  
  ![image](https://user-images.githubusercontent.com/50028950/145574146-5348536c-73af-4127-b2f1-6727b16c5903.png)

 8. These steps will ensure our API can call the SQL Server running in the container and get the data.
 
 9. Finally we need to update the docker-compose.yml file to add the SQL Server details as well. Add a dependency between the API and DB using depends_on 
 
    ![image](https://user-images.githubusercontent.com/50028950/145574431-73aee737-e6ea-42e9-b7af-5ee43bdeba45.png)
    
  10. Change the API code to get the data from DB rather than the static list. (context is the DBContext class created earlier). 
  
       ![image](https://user-images.githubusercontent.com/50028950/145574827-cb1d52fa-1c6b-40bf-af0b-0a20b35ed632.png)
 
    
 11. In the Docker compose these are the 3 services running
      a. docker.multiapp.api - API project running in its own container
      b. docker.multiapp.web - Web project running in its own container
      c. dockermultiappdb    - SQL Server running in a seperate container.
      
  11. We can confirm the same by expanding the Docker compose in the Docker destop and validate all the 3 containers are up and running. 

      ![image](https://user-images.githubusercontent.com/50028950/145574961-e9ae6fd2-266e-4639-aed4-b36cb47834ef.png)

  12. Now if you open a browser and hit https://localhost:9000, you can see the API connecting to DB and getting the data.
  
     ![image](https://user-images.githubusercontent.com/50028950/145576390-96f9727a-55d8-42cb-8231-1a5fd591ceee.png)

     
   13. Finally, the UI will be displayed with a single book record selected randomly from the DB as below.
    
     ![image](https://user-images.githubusercontent.com/50028950/145576432-7072bec6-1b7f-4a1c-8b2b-5fa0e69adbd3.png)



  


 
 







 
