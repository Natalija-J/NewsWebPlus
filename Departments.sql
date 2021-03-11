CREATE TABLE Departments(
	Dep_Id INT NOT NULL,
	Dep_Name NVARCHAR(50) NULL,
	Dep_Location NVARCHAR(200) NULL
)

-- 2. Fill ‘Departments’ with sample data:

INSERT INTO Departments(Dep_Id, Dep_Name, Dep_Location)
VALUES(101, 'HQ','SYDNEY')

INSERT INTO Departments(Dep_Id, Dep_Name, Dep_Location)
VALUES(201, 'SUPPORT','MELBOURNE')

INSERT INTO Departments(Dep_Id, Dep_Name, Dep_Location)
VALUES(301, 'MARKETING','PERTH')

INSERT INTO Departments(Dep_Id, Dep_Name, Dep_Location)
VALUES(401, 'PRODUCTION','BRISBANE')