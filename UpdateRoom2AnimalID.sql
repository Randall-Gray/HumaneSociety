UPDATE Rooms
SET
AnimalId = (SELECT AnimalId FROM Animals WHERE Name = 'Scooby')
WHERE RoomId = 2