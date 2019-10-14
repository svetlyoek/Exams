CREATE FUNCTION udf_CalculateTickets
(@Origin      NVARCHAR(50), 
 @Destination NVARCHAR(50), 
 @PeopleCount INT
)
RETURNS NVARCHAR(30)
AS
     BEGIN
         IF(@PeopleCount <= 0)
             BEGIN
                 RETURN 'Invalid people count!';
         END;
         DECLARE @TotalPrice DECIMAL(15, 2)=
         (
             SELECT SUM(t.Price)
             FROM Flights AS f
                  JOIN Tickets AS t ON f.Id = t.FlightId
             WHERE f.Origin = @Origin
                   AND f.Destination = @Destination
         );
         DECLARE @FlightId INT=
         (
             SELECT f.Id
             FROM Flights AS f
             WHERE f.Origin = @Origin
                   AND f.Destination = @Destination
         );
         IF(@FlightId IS NULL)
             BEGIN
                 RETURN 'Invalid flight!';
         END;
         SET @TotalPrice*=@PeopleCount;
         RETURN 'Total price ' + CAST(@TotalPrice AS NVARCHAR);
     END;