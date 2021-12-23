# Multi Container Application Configuration options.
In the previous article, I created a simple docker compose file which has the details of a FrontEnd/API/DB server all created using a singled docker compose file.
So far this looks fine and it is easy to create and also tear down the containers using the docker-compose up and dockerp-compose down commands.

One problem with the current approach is we have added a lot of hardcoded data for Ports/DB credentails etc in our docker compose file. This is rarely the case. Additionally
if we have to deploy the images to DEV/QA/Staging and Production environments, the ports/credentials/URLs of the APIs and the authentication mechanisms are all different for different environments. These are mostly configuration items that needs to be injected/used the applications during run time. We should have similar apporach for docker files as well. 

In this post, I will explore the different ways of building multiple enviroments in Docker ecosystem.


# Approach 1:  Multiple docker-compose files for different environments
One of the first thougths is to have a docker compose file targeting each environment like below.
![image](https://user-images.githubusercontent.com/50028950/147246672-e3ffbcb2-6898-421a-8286-02d14d682693.png)

This way you can segregate the information b/w different environments and also add permissions to the docker compose yml files.

For the sake of simplicity, I just changed the ports on which these two compose files run for the Web and SQL Server.

QA Docker Compose file : 

![image](https://user-images.githubusercontent.com/50028950/147247643-04bcada6-8a5b-4f42-8d93-a4365b09eb1b.png)

So if you run the QA compose file, you can check the webapp using http://localhost:8001 and DB on port 1434.

Prod  Docker Compose file :

![image](https://user-images.githubusercontent.com/50028950/147247808-cc002057-3368-4d89-b3a6-a36f7921e04d.png)

So if you run the Prod compose file, you can check the webapp using http://localhost:5001 and DB on port 1435

While building the compose files, you can specify which yaml file needs to be used to the docker compose file using the -f and -p tags for the file and name properties
during runtime as below.

QA Docker Compose :

![image](https://user-images.githubusercontent.com/50028950/147247334-4cbc9801-59e2-4c62-8e5f-4a2b7f27fe95.png)


Prod Docker Compose : 

![image](https://user-images.githubusercontent.com/50028950/147247234-8659b651-0fff-46b5-919b-d2cfa5679f6d.png)


If you open the Docker desktop, you can see both the compose files running on different ports based on the configuration.

![image](https://user-images.githubusercontent.com/50028950/147248142-6c2781aa-fd5e-4fe0-b85e-b778dd676d56.png)

You can browse the different URLs as well and check the same. 


![image](https://user-images.githubusercontent.com/50028950/147248460-22a371db-e5da-4fb5-88b8-e416a9ad6da6.png)


![image](https://user-images.githubusercontent.com/50028950/147248557-f9e3f631-571c-4735-a2bf-e88611e0f250.png)

# Approach 2:  Single Docker Compose file with different Environment variables
TBD


 

  


 
 







 
