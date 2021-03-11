SELECT LastName, FirstName FROM Users

SELECT * FROM Users
-- one line comment
/*
multiple lines comment. but these comments don't get stored
*/
INSERT INTO Users (Id, LastName, FirstName, RegisteredOn)
VALUES (1, 'Smith', 'John', '2021-02-27')
INSERT INTO Users (Id, LastName, FirstName, RegisteredOn)
VALUES (2, 'Adams', 'Ann', '2021-02-20')

SELECT * FROM Users ORDER BY LastName ASC, FirstName ASC
SELECT * FROM Users ORDER BY RegisteredOn DESC

-- sql is not case sensitive / can use small letters for commands

INSERT INTO Users (Id, LastName, FirstName, RegisteredOn)
VALUES (3, 'Test', 'Test', '2021-02-20')

UPDATE Users SET RegisteredOn = '2021-01-01', FirstName = 'New Name' WHERE LastName = 'Test'

DELETE FROM Users WHERE Id = 3

SELECT * FROM Users
WHERE Id = 1
ORDER BY RegisteredOn DESC

SELECT * FROM Users
WHERE LastName = 'Smith' AND FirstName = 'John'
ORDER BY RegisteredOn DESC

SELECT * FROM Users
WHERE Id > 0

SELECT * FROM Users
WHERE RegisteredOn <= '2021-02-27' 

SELECT MAX(Id) FROM Users