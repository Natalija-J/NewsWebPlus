--1. Create a new database table ‘Orders’ with structure and data like this:
CREATE TABLE Orders(
	Order_id INT NOT NULL, 
	Order_sum DECIMAL(8,2) NULL, 
	Order_date DATETIME NULL
	)


INSERT INTO Orders(Order_id, Order_sum, Order_date)
VALUES(15001, 150.5, '2018-10-05')
INSERT INTO Orders(Order_id, Order_sum, Order_date)
VALUES(15002, 270.65, '2018-09-10')
INSERT INTO Orders(Order_id, Order_sum, Order_date)
VALUES(16000, 65.26, '2018-10-05')
INSERT INTO Orders(Order_id, Order_sum, Order_date)
VALUES(16005, 110.5, '2018-08-17')
INSERT INTO Orders(Order_id, Order_sum, Order_date)
VALUES(17000, 948.5, '2018-09-10')


-- 2. Select all orders and it’s data.
SELECT * FROM Orders

--3. Select all order sums in descending order.
SELECT * FROM Orders ORDER BY Order_sum DESC

--4. Select all order identifiers where sum is above 150.
SELECT * FROM Orders WHERE Order_sum > 150

--5. Select all orders that were in october 2018.
SELECT * FROM Orders WHERE Order_date >= '2018-10-01' AND Order_date < '2018-11-01'

ALTER TABLE Orders ALTER COLUMN Order_sum INT NULL
ALTER TABLE Orders ALTER COLUMN Order_date DATETIME NULL

--6. Add a new record to the table (with identifier 18000).
INSERT INTO Orders(Order_id)
VALUES(18000)

--7. Change order’s #17000 sum to 1000.
UPDATE Orders SET Order_sum = 1000  WHERE Order_id = 17000

--8. Delete a record added in step 6 (by identifier).
DELETE FROM Orders WHERE Order_id = 18000

--10. Add a new column ‘Order_user_id’ to table ‘Orders’ and fill data as shown below:
ALTER TABLE Orders ADD Order_client_id INT NULL
UPDATE Orders SET Order_client_id = 10000 WHERE Order_id = 15001
UPDATE Orders SET Order_client_id = 10000 WHERE Order_id = 15002
UPDATE Orders SET Order_client_id = 10000 WHERE Order_id = 16005
UPDATE Orders SET Order_client_id = 11000 WHERE Order_id = 16000
UPDATE Orders SET Order_client_id = 11000 WHERE Order_id = 17000

--11. Select all orders and their corresponding user’s data.
SELECT * FROM Orders, Clients WHERE Order_client_id = Client_id

--12. Select count how many orders have done user John Smith (by name).
SELECT COUNT(Order_id)
FROM Orders
WHERE Order_client_id = 10000

--13. Select orders total sum for user Kate Miller (by name)
SELECT SUM(Order_sum)
FROM Orders
WHERE Order_client_id = 11000

--14. Select the last two orders for user John Smith (by name).

SELECT TOP(2) o.Order_id, o.Order_sum, o.Order_date 
FROM Orders o, Clients c 
WHERE o.Order_client_id = c.Client_id AND c.Client_name = 'John' AND c.Client_surname = 'Smith'
ORDER BY Order_date DESC



--15. Create one SQL script file ‘task2.sql’ that contains commands for each of the steps above.


 