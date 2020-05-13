INSERT INTO Addresses(AddressId, AddressLine1, USStateId, Zipcode)
VALUES ('1600 Palmer Rd',(SELECT USStateId FROM USStates WHERE Name = 'Texas'),78723);
INSERT INTO Addresses(AddressId, AddressLine1, USStateId, Zipcode)
VALUES ('2222 Wenonah Ave',(SELECT USStateId FROM USStates WHERE Name = 'Alabama'),35211);
INSERT INTO Addresses(AddressId, AddressLine1, USStateId, Zipcode)
VALUES ('967 Martin Luther Blvd',(SELECT USStateId FROM USStates WHERE Name = 'Texas'),76501);
INSERT INTO Addresses(AddressId, AddressLine1, USStateId, Zipcode)
VALUES ('400 Oak Bark Lane ',(SELECT USStateId FROM USStates WHERE Name = 'Tennessee'),37501);
INSERT INTO Addresses(AddressId, AddressLine1, USStateId, Zipcode)
VALUES ('100 WoodLand Drive',(SELECT USStateId FROM USStates WHERE Name = 'Tennessee'),37011);
