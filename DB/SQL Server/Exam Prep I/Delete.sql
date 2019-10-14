DELETE FROM Tickets
WHERE FlightId IN
(
    SELECT f.Id
    FROM Flights AS f
    WHERE f.Id = FlightId
);
DELETE FROM Planes
WHERE Id IN
(
    SELECT f.PlaneId
    FROM Flights AS f
    WHERE f.PlaneId = Id
);
DELETE FROM Flights
WHERE Destination = 'Ayn Halagim';