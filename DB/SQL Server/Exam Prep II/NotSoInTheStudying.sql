SELECT CASE
           WHEN s.MiddleName IS NULL
           THEN concat(s.FirstName, ' ', s.LastName)
           ELSE concat(s.FirstName, ' ', s.MiddleName, ' ', s.LastName)
       END AS [Full Name]
FROM Students AS s
     LEFT JOIN StudentsSubjects AS ss ON s.Id = ss.StudentId
     LEFT JOIN Subjects AS sb ON ss.SubjectId = sb.Id
WHERE sb.Id IS NULL
ORDER BY [Full Name];