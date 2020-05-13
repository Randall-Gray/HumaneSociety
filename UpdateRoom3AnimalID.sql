UPDATE Rooms
SET
AnimalId = (SELECT AnimalId FROM Animals WHERE Name = 'The word')
WHERE RoomId = 3