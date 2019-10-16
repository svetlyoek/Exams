CREATE FUNCTION udf_ExamGradesToUpdate
(@StudentId INT, 
 @Grade     DECIMAL(15, 2)
)
RETURNS VARCHAR(200)
AS
     BEGIN
         DECLARE @StudentName NVARCHAR(30)=
         (
             SELECT s.[FirstName]
             FROM Students AS s
             WHERE s.Id = @StudentId
         );
         DECLARE @GradeCount INT;
         DECLARE @Id INT=
         (
             SELECT s.Id
             FROM Students AS s
             WHERE s.Id = @StudentId
         );
         IF(@Id IS NULL)
             BEGIN
                 RETURN 'The student with provided id does not exist in the school!';
         END;
             ELSE
             IF(@Grade > 6.00)
                 BEGIN
                     RETURN 'Grade cannot be above 6.00!';
             END;
         SET @GradeCount =
         (
             SELECT COUNT(se.Grade)
             FROM Students AS s
                  JOIN StudentsExams AS se ON s.Id = se.StudentId
             WHERE s.Id = @StudentId
                   AND se.Grade BETWEEN @Grade AND @Grade + 0.50
         );
         RETURN 'You have to update' + ' ' + CAST(@GradeCount AS NVARCHAR) + ' ' + 'grades' + ' ' + 'for the student' + ' ' + CAST(@StudentName AS NVARCHAR);
     END;
SELECT dbo.udf_ExamGradesToUpdate(12, 6.20);
SELECT dbo.udf_ExamGradesToUpdate(12, 5.50);
SELECT dbo.udf_ExamGradesToUpdate(121, 5.50);