UPDATE Animals
SET
EmployeeId = (SELECT EmployeeId FROM Employees WHERE FirstName = 'Burt')
WHERE Name = 'The word'