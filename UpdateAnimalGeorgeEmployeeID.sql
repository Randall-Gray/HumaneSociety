UPDATE Animals
SET
EmployeeId = (SELECT EmployeeId FROM Employees WHERE FirstName = 'Turd')
WHERE Name = 'George'