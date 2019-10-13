CREATE PROC usp_FindByExtension(@Extension NVARCHAR(100))
AS
    BEGIN
        SELECT f.Id, 
               f.[Name], 
               concat(f.[Size], 'KB') AS [Size]
        FROM Files AS f
        WHERE f.[Name] LIKE '%' + @Extension
        ORDER BY f.Id ASC, 
                 f.[Name] ASC, 
                 [Size] DESC;
    END;