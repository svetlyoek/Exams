SELECT s.FirstName, 
       s.LastName, 
       COUNT(t.Id) AS [teachersCount]
FROM Students AS s
     JOIN StudentsTeachers AS st ON s.Id = st.StudentId
     JOIN Teachers AS t ON t.Id = st.TeacherId
GROUP BY s.FirstName, 
         s.LastName;