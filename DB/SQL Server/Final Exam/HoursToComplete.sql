CREATE FUNCTION udf_HoursToComplete
(@StartDate DATETIME, 
 @EndDate   DATETIME
)
RETURNS INT
AS
     BEGIN
         DECLARE @Start DATETIME=
         (
             SELECT r.OpenDate
             FROM Reports AS r
             WHERE r.OpenDate = @StartDate
         );
         IF(@Start IS NULL)
             BEGIN
                 RETURN 0;
         END;
         DECLARE @End DATETIME=
         (
             SELECT r.CloseDate
             FROM Reports AS r
             WHERE r.CloseDate = @EndDate
         );
         IF(@End IS NULL)
             BEGIN
                 RETURN 0;
         END;
         RETURN DATEDIFF(second, @Start, @End) / 3600;
     END;