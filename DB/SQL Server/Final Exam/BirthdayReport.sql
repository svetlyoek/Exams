SELECT u.Username, 
       c.[Name] AS [CategoryName]
FROM Reports AS r
     JOIN Categories AS c ON r.CategoryId = c.Id
     JOIN Users AS u ON r.UserId = u.Id
WHERE DAY(r.OpenDate) = DAY(u.Birthdate)
      AND MONTH(r.OpenDate) = MONTH(u.BirthDate)
ORDER BY u.Username, 
         [CategoryName];