UPDATE Tickets
  SET 
      Price = Price + (Price * 0.13)
WHERE FlightId IN
(
    SELECT f.Id
    FROM Flights AS f
    WHERE f.Destination = 'Carlsbad'
);