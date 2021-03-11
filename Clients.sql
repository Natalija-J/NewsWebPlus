--9. Create a new database table ‘Clients’:

CREATE TABLE CLients(
	Client_id NVARCHAR(50) NOT NULL,
	Client_name NVARCHAR(50) NULL, 
	Client_surname NVARCHAR(50) NULL
)

SELECT * FROM Clients
INSERT INTO Clients(Client_id, Client_name, Client_surname)
VALUES(10000, 'John', 'Smith')

INSERT INTO Clients(Client_id, Client_name, Client_surname)
VALUES(11000, 'Kate', 'Miller')

ALTER TABLE Clients DROP COLUMN Order_CLient_id
