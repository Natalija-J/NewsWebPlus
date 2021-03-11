CREATE TABLE Salary_Grades(
	Grade_Id INT NOT NULL,
	Grade_Min_Salary INT NULL,
	Grade_Max_Salary INT NULL,
)

 -- 4. Fill ‘Salary_Grades’ with sample data:

INSERT INTO Salary_Grades(Grade_Id, Grade_Min_Salary, Grade_Max_Salary)
VALUES(1, 800, 1300)

INSERT INTO Salary_Grades(Grade_Id, Grade_Min_Salary, Grade_Max_Salary)
VALUES(2, 1301, 1500)

INSERT INTO Salary_Grades(Grade_Id, Grade_Min_Salary, Grade_Max_Salary)
VALUES(3, 1501, 2100)

INSERT INTO Salary_Grades(Grade_Id, Grade_Min_Salary, Grade_Max_Salary)
VALUES(4, 2101, 3100)

INSERT INTO Salary_Grades(Grade_Id, Grade_Min_Salary, Grade_Max_Salary)
VALUES(5, 3101, 9999)

