INSERT INTO Employees(FirstName, LastName, UserName, Password, EmployeeNumber, Email)
VALUES ('Telvin', 'Mathews', 'Telvin2021','2536', (SELECT AddressId  from Addresses where City = 'Austin'), 'jh@gmail.com');
INSERT INTO Employees(FirstName, LastName, UserName, Password, EmployeeNumber, Email)
VALUES ('Burt', 'Macklin', 'BurtTheFlirt','6275', (SELECT AddressId  from Addresses where City = 'Birmingham'), 'jillhill@gmail.com');
INSERT INTO Employees(FirstName, LastName, UserName, Password, EmployeeNumber, Email)
VALUES ('Art', 'Vandely', 'JimmyHill','89827', (SELECT AddressId  from Addresses where City = 'Temple'), 'jimmyhill@gmail.com');
INSERT INTO Employees(FirstName, LastName, UserName, Password, EmployeeNumber, Email)
VALUES ('Rusty', 'Shackleford', 'JamesHill','0282', (SELECT AddressId  from Addresses where City = 'Memphis'), 'jameshill@gmail.com');
INSERT INTO Employees(FirstName, LastName, UserName, Password, EmployeeNumber, Email)
VALUES ('Turd', 'Ferguson', 'LuckKang','15242', (SELECT AddressId  from Addresses where City = 'Nashville'), 'Luckkang@gmail.com');