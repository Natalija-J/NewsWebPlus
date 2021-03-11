CREATE TABLE Employees(
	Emp_Id INT NOT NULL, 
	Emp_Name NVARCHAR(50) NULL, 
	Emp_Job_Name NVARCHAR(50) NOT NULL, 
	Emp_Manager_Id INT NULL, 
	Emp_Hire_Date DATETIME NOT NULL, 
	Emp_Salary DECIMAL (8,2) NOT NULL,  
	Emp_Department_Id INT NOT NULL, 
)

-- 3. Fill ‘Employees’ with sample data:

INSERT INTO Employees(Emp_Id, Emp_Name, Emp_Job_Name, Emp_Hire_Date, Emp_Salary, Emp_Department_Id)
VALUES(10010, 'JOHN','PRESIDENT', '1990-12-19', 6000.00, 101)
INSERT INTO Employees(Emp_Id, Emp_Name, Emp_Job_Name, Emp_Manager_Id, Emp_Hire_Date, Emp_Salary, Emp_Department_Id)
VALUES(10020, 'MISTY','MANAGER', 10010, '1990-06-02', 2750.00, 301)
INSERT INTO Employees(Emp_Id, Emp_Name, Emp_Job_Name, Emp_Manager_Id, Emp_Hire_Date, Emp_Salary, Emp_Department_Id)
VALUES(10030, 'ADAM','MANAGER', 10010, '1990-07-08', 2550.00, 101)
INSERT INTO Employees(Emp_Id, Emp_Name, Emp_Job_Name, Emp_Manager_Id, Emp_Hire_Date, Emp_Salary, Emp_Department_Id)
VALUES(10040, 'PEPPER','EXECUTIVE', 10010, '1990-03-32', 2957.00, 201)
INSERT INTO Employees(Emp_Id, Emp_Name, Emp_Job_Name, Emp_Manager_Id, Emp_Hire_Date, Emp_Salary, Emp_Department_Id)
VALUES(10050, 'SCARLET','ANALYST', 10040, '1996-03-18', 3100.00, 201)
INSERT INTO Employees(Emp_Id, Emp_Name, Emp_Job_Name, Emp_Manager_Id, Emp_Hire_Date, Emp_Salary, Emp_Department_Id)
VALUES(10060, 'PATRICK','TECHNICIAN', 10040, '1990-12-03', 3100.00, 201)
