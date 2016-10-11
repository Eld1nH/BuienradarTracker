CREATE DATABASE BuienradarTracker;
GO

CREATE TABLE BuienradarTracker.dbo.Subscription
(
	Id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	WeatherStationCode nvarchar(10) NOT NULL,
	Gender nvarchar(max) NULL,
	Initials nvarchar(max) NULL,
	FirstNames nvarchar(max) NULL,
	Prefix nvarchar(max) NULL,
	LastName nvarchar(max) NULL,
	EmailAddress nvarchar(256) NOT NULL,
	CONSTRAINT UQ_Subscriptions_WeatherStationCode_EmailAddress UNIQUE(WeatherStationCode, EmailAddress)
);