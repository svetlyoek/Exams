SELECT s.FirstName, 
       s.LastName, 
       s.Age
FROM Students AS s
WHERE s.Age >= 12
ORDER BY s.FirstName, 
         s.LastName;