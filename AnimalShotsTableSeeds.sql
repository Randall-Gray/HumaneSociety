INSERT INTO AnimalShots (AnimalId, ShotId)
VALUES ((SELECT AnimalId from Animals where Name = 'Loki'), (SELECT ShotId from Shots where Name = 'Core Vaccines'));
INSERT INTO AnimalShots (AnimalId, ShotId)
VALUES ((SELECT AnimalId from Animals where Name = 'Scooby'), (SELECT ShotId from Shots where Name = 'Rabies Virus Vaccines'));
INSERT INTO AnimalShots (AnimalId, ShotId)
VALUES ((SELECT AnimalId from Animals where Name = 'The Word'), (SELECT ShotId from Shots where Name = 'Leptospira Vaccines'));
INSERT INTO AnimalShots (AnimalId, ShotId)
VALUES ((SELECT AnimalId from Animals where Name = 'George'), (SELECT ShotId from Shots where Name = 'Non-Core Vaccines'));
INSERT INTO AnimalShots (AnimalId, ShotId)
VALUES ((SELECT AnimalId from Animals where Name = 'Blue'), (SELECT ShotId from Shots where Name = 'Influenza Virus'));