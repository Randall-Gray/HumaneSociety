UPDATE Rooms
SET
AnimalId = (SELECT AnimalId FROM Animals WHERE Name = 'Loki')
WHERE RoomId = 1