SELECT r.[Description], 
       format(r.OpenDate, 'dd-MM-yyyy')
FROM Reports AS r
WHERE EmployeeId IS NULL
ORDER BY r.OpenDate, 
         r.[Description];