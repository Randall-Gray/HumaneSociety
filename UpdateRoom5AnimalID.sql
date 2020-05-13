UPDATE Rooms
SET
AnimalId = (SELECT AnimalId FROM Animals WHERE Name = 'Blue')
WHERE RoomId = 5