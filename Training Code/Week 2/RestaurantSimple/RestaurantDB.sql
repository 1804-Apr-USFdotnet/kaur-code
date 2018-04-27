CREATE DATABASE RestaurantDB;

USE RestaurantDB;
GO

CREATE SCHEMA Restaurant;

CREATE TABLE Restaurant.Restaurant
(
	[ID] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
);

SELECT * FROM Restaurant.Restaurant;