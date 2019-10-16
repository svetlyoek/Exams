CREATE PROC usp_ExcludeFromSchool(@StudentId INT)
AS
    BEGIN
        DECLARE @Id INT=
        (
            SELECT s.Id
            FROM Students AS s
            WHERE s.Id = @StudentId
        );
        IF(@Id IS NULL)
            BEGIN
                RAISERROR('This school has no student with the provided id!', 16, 1);
        END;
            ELSE
            BEGIN
                DELETE FROM StudentsExams
                WHERE StudentId = @StudentId;
                DELETE FROM StudentsSubjects
                WHERE StudentId = @StudentId;
                DELETE FROM StudentsTeachers
                WHERE StudentId = @StudentId;
                DELETE FROM Students
                WHERE Id = @StudentId;
        END;
    END;

	EXEC usp_ExcludeFromSchool 1
SELECT COUNT(*) FROM Students
EXEC usp_ExcludeFromSchool 
     301;