UPDATE Animals
SET
EmployeeId = (SELECT EmployeeId FROM Employees WHERE FirstName = 'Rusty')
WHERE Name = 'Scooby'