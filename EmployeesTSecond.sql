
SELECT * FROM Employees

INSERT INTO Employees(Emp_Id, Emp_Name,Emp_Job_Name, Emp_Manager_Id, Emp_Hire_Date, 
Emp_Salary, Emp_Department_Id)
VALUES  (10040, 'PEPPER', 'EXECUTIVE', 10010, '1990-03-31', 2957.00, 201)

INSERT INTO Employees(Emp_Id, Emp_Name,  Emp_Job_Name, Emp_Hire_Date, 
Emp_Salary, Emp_Department_Id)
VALUES  (10010, 'JOHN', 'PRESIDENT', '1990-12-19', 6000.00, 101)

ALTER TABLE Employees ALTER COLUMN Emp_Manager_Id INT NULL