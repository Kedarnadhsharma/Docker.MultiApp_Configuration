USE [master] 
GO 
 
CREATE DATABASE [DockerAppDB] 
GO 
 
USE [DockerAppDB] 
GO 
 

 
CREATE TABLE [Books] 
( 
    [Id] [int] IDENTITY(1,1) NOT NULL, 
    [Name] [nvarchar](50) NOT NULL, 
    [Author] [nvarchar](50) NOT NULL, 
    [Category] [nvarchar](50) NOT NULL, 
    [Price] [decimal](10, 2) NOT NULL 
 CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED ([Id] ASC) ON [PRIMARY] 
) ON [PRIMARY] 
GO

INSERT INTO Books (Name, Author, Category, Price) VALUES ('Thinking Fast and Slow','Daniel Kanhneman','Economics',400)
INSERT INTO Books (Name, Author, Category, Price) VALUES ('MisBehaving','Richard Thaler','Economics',500)
INSERT INTO Books (Name, Author, Category, Price) VALUES ('Why We Sleep','Mathew Walker','Health Sciences',900)
INSERT INTO Books (Name, Author, Category, Price) VALUES ('12 Rules for Life','Jordan Peterson','Philosophy',600)
INSERT INTO Books (Name, Author, Category, Price) VALUES ('Docker Deep Dive','Nigel Poulton','Computer/IT',400)


 GO 
               
     
 
