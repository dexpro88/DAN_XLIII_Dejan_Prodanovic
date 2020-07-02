--we create database  
CREATE DATABASE WorkingHoursDB;
GO

use WorkingHoursDB;

GO

 --we delete tables in case they exist
 
DROP TABLE IF EXISTS tblEmployee;
DROP TABLE IF EXISTS tblSector;
DROP TABLE IF EXISTS tblRole;
DROP TABLE IF EXISTS tblReport;

--we create table tblSector
 CREATE TABLE tblSector (
    SectorID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    SectorName varchar(50)   
);

--we create table tblRole
 CREATE TABLE tblRole (
    RoleID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    RoleName varchar(50)   
);

--we create table tblEmployee
CREATE TABLE tblEmployee (
    EmployeeID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    FirstName varchar(50),
	LastName varchar(50),
	DateOfBirth date,
	JMBG varchar(50),
	AccountNumber varchar(50),
    Email varchar(50),  
	Salary decimal,
	Position varchar(50), 
	Username varchar(50),
	Passwd varchar(50),
	IsMenager BIT,
	SectorID int FOREIGN KEY REFERENCES tblSector(SectorID),
	RoleID int FOREIGN KEY REFERENCES tblRole(RoleID) 
	
);


--we create table tblReport
CREATE TABLE tblReport (
    ReportID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	DateOfReport date,
	Project varchar(50),
	Position varchar(50),
    NumberOfHours decimal,  
	EmployeeID int FOREIGN KEY REFERENCES tblEmployee(EmployeeID)
	 
);


GO
CREATE VIEW vwReport
AS

SELECT   dbo.tblEmployee.FirstName + ', '+dbo.tblEmployee.LastName  AS FullName,dbo.tblEmployee.EmployeeID,
         dbo.tblReport.Project, dbo.tblReport.DateOfReport, dbo.tblReport.Position,
		 dbo.tblReport.NumberOfHours,dbo.tblReport.ReportID
		
FROM            dbo.tblEmployee  INNER JOIN
            dbo.tblReport ON dbo.tblReport.EmployeeID = dbo.tblEmployee.EmployeeID
GO

SELECT * FROM vwReport;
SELECT * FROM tblEmployee;

INSERT INTO tblRole VALUES('modify');
INSERT INTO tblRole VALUES('read-only');

INSERT INTO tblSector VALUES('HR');
INSERT INTO tblSector VALUES('Financions');