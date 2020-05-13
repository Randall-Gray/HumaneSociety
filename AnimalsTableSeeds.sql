INSERT INTO Animals(AnimalId, Name, Weight, Age, Demeanor, KidFriendly, PetFriendly, Gender, AdoptionStatus, CategoryId, DietPlanId, EmployeeId)
VALUES ('Loki', 30, 3, 'pickey', 1, 1,'closed',(SELECT CategoryId FROM Categories WHERE Name = 'Cat'),(SELECT DietPlanId FROM DietPlans WHERE Name = 'RawMeat'), (SELECT EmployeeId FROM Employees WHERE FirstName = 'Telvin'));
INSERT INTO Animals(AnimalId, Name, Weight, Age, Demeanor, KidFriendly, PetFriendly, Gender, AdoptionStatus, CategoryId, DietPlanId, EmployeeId)
VALUES ('Scooby', 100, 10, 'goofy', 0, 0,'closed',(SELECT CategoryId FROM Categories WHERE Name = 'Dog'),(SELECT DietPlanId FROM DietPlans WHERE Name = 'Dry'), (SELECT EmployeeId FROM Employees WHERE FirstName = 'Burt'));
INSERT INTO Animals(AnimalId, Name, Weight, Age, Demeanor, KidFriendly, PetFriendly, Gender, AdoptionStatus, CategoryId, DietPlanId, EmployeeId)
VALUES ('The Word', 8, 1, 'annoying', 1, 1,'open',(SELECT CategoryId FROM Categories WHERE Name = 'Bird'),(SELECT DietPlanId FROM DietPlans WHERE Name = 'Dry'), (SELECT EmployeeId FROM Employees WHERE FirstName = 'Art'));
INSERT INTO Animals(AnimalId, Name, Weight, Age, Demeanor, KidFriendly, PetFriendly, Gender, AdoptionStatus, CategoryId, DietPlanId, EmployeeId)
VALUES ('George', 20, 2, 'mean', 1, 1,'open',(SELECT CategoryId FROM Categories WHERE Name = 'Chicken'),(SELECT DietPlanId FROM DietPlans WHERE Name = 'Dry'), (SELECT EmployeeId FROM Employees WHERE FirstName = 'Rusty'));
INSERT INTO Animals(AnimalId, Name, Weight, Age, Demeanor, KidFriendly, PetFriendly, Gender, AdoptionStatus, CategoryId, DietPlanId, EmployeeId)
VALUES ('Blue', 300, 7, 'freindly', 1, 1,'open',(SELECT CategoryId FROM Categories WHERE Name = 'Bear'),(SELECT DietPlanId FROM DietPlans WHERE Name = 'RawMeat'), (SELECT EmployeeId FROM Employees WHERE FirstName = 'Turd'));

