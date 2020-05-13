UPDATE Animals
SET
EmployeeId = (SELECT EmployeeId FROM Employees WHERE FirstName = 'Telvin')
WHERE Name = 'Loki'