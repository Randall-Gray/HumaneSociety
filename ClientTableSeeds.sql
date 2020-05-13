INSERT INTO Clients(FirstName, LastName, UserName, Password, AddressId, Email)
VALUES ('Jack', 'Hill', 'JackHill','2536', (SELECT AddressId  from Addresses where City = 'Austin'), 'jh@gmail.com');
INSERT INTO Clients(FirstName, LastName, UserName, Password, AddressId, Email)
VALUES ('Jill', 'Hill', 'JillHill','6275', (SELECT AddressId  from Addresses where City = 'Birmingham'), 'jillhill@gmail.com');
INSERT INTO Clients(FirstName, LastName, UserName, Password, AddressId, Email)
VALUES ('Jimmy', 'Hill', 'JimmyHill','89827', (SELECT AddressId  from Addresses where City = 'Temple'), 'jimmyhill@gmail.com');
INSERT INTO Clients(FirstName, LastName, UserName, Password, AddressId, Email)
VALUES ('James', 'Hill', 'JamesHill','0282', (SELECT AddressId  from Addresses where City = 'Memphis'), 'jameshill@gmail.com');
INSERT INTO Clients(FirstName, LastName, UserName, Password, AddressId, Email)
VALUES ('Luck', 'Kang', 'LuckKang','15242', (SELECT AddressId  from Addresses where City = 'Nashville'), 'Luckkang@gmail.com');