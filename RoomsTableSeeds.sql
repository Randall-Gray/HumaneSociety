INSERT INTO Rooms(RoomId, RoomNumber, AnimalId)
VALUES (1, (SELECT AnimalId FROM Animals WHERE Name = 'Loki' ));
INSERT INTO Rooms(RoomId, RoomNumber, AnimalId)
VALUES (2, (SELECT AnimalId FROM Animals WHERE Name = 'Scooby' ));
INSERT INTO Rooms(RoomId, RoomNumber, AnimalId)
VALUES (3, (SELECT AnimalId FROM Animals WHERE Name = 'The Word' ));
INSERT INTO Rooms(RoomId, RoomNumber, AnimalId)
VALUES (4, (SELECT AnimalId FROM Animals WHERE Name = 'George' ));
INSERT INTO Rooms(RoomId, RoomNumber, AnimalId)
VALUES (5, (SELECT AnimalId FROM Animals WHERE Name = 'Blue' ));
