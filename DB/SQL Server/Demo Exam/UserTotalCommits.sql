CREATE FUNCTION udf_UserTotalCommits
(@Username NVARCHAR(30)
)
RETURNS INT
AS
     BEGIN
         DECLARE @Count INT=
         (
             SELECT COUNT(c.ContributorId)
             FROM Users AS u
                  JOIN Commits AS c ON u.Id = c.ContributorId
             WHERE u.Username = @Username
         );
         RETURN @Count;
     END;