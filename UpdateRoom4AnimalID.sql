UPDATE Rooms
SET
AnimalId = (SELECT AnimalId FROM Animals WHERE Name = 'George')
WHERE RoomId = 4