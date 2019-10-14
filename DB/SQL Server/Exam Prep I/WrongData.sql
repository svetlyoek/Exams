CREATE PROC usp_CancelFlights
AS
    BEGIN
        UPDATE Flights
          SET 
              DepartureTime = NULL, 
              ArrivalTime = NULL
        WHERE DATEDIFF(second, ArrivalTime, DepartureTime) < 0;
    END;