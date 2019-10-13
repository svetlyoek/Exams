SELECT f2.Id, 
       f2.[Name], 
       concat(f2.[Size], 'KB') AS [Size]
FROM Files AS f
     RIGHT JOIN Files AS f2 ON f.ParentId = f2.Id
WHERE f.ParentId IS NULL
ORDER BY f2.Id ASC, 
         f2.[Name] ASC, 
         [Size] DESC;