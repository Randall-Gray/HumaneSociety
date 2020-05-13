INSERT INTO Adoptions(ClientId, AnimalId,ApprovalStatus,AdoptionFee,PaymentCollected)
VALUES ((SELECT ClientId FROM Clients WHERE FirstName = 'Jack'),(SELECT AnimalId FROM Animals WHERE Name = 'Loki'), 'approved', 50, 0);
INSERT INTO Adoptions(ClientId, AnimalId,ApprovalStatus,AdoptionFee,PaymentCollected)
VALUES ((SELECT ClientId FROM Clients WHERE FirstName = 'Jill'),(SELECT AnimalId FROM Animals WHERE Name = 'Scooby'), 'approved', 50, 1);
INSERT INTO Adoptions(ClientId, AnimalId,ApprovalStatus,AdoptionFee,PaymentCollected)
VALUES ((SELECT ClientId FROM Clients WHERE FirstName = 'Jimmy'),(SELECT AnimalId FROM Animals WHERE Name = 'The Word'), 'approved', 50, 0);
INSERT INTO Adoptions(ClientId, AnimalId,ApprovalStatus,AdoptionFee,PaymentCollected)
VALUES ((SELECT ClientId FROM Clients WHERE FirstName = 'James'),(SELECT AnimalId FROM Animals WHERE Name = 'George'), 'not approved', 50, 1);
INSERT INTO Adoptions(ClientId, AnimalId,ApprovalStatus,AdoptionFee,PaymentCollected)
VALUES ((SELECT ClientId FROM Clients WHERE FirstName = 'Luck'),(SELECT AnimalId FROM Animals WHERE Name = 'Blue'), 'not approved', 50, 1);
