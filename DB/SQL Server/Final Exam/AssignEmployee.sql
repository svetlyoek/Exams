CREATE PROCEDURE usp_AssignEmployeeToReport
(@EmployeeId INT, 
 @ReportId   INT
)
AS
    BEGIN
        DECLARE @EmployeeDepartment INT=
        (
            SELECT [e].[DepartmentId]
            FROM [dbo].[Employees] AS e
            WHERE [e].[Id] = @EmployeeId
        );
        DECLARE @ReportDepartment INT=
        (
            SELECT [c].[DepartmentId]
            FROM [dbo].[Reports] AS r
                 JOIN [dbo].[Categories] AS [c] ON [r].[CategoryId] = [c].[Id]
            WHERE [r].[Id] = @ReportId
        );
        IF(@EmployeeDepartment <> @ReportDepartment)
            BEGIN
                RAISERROR('Employee doesn''t belong to the appropriate department!', 16, 1);
                RETURN;
        END;
        UPDATE [dbo].[Reports]
          SET 
              [dbo].[Reports].[EmployeeId] = @EmployeeId
        WHERE [dbo].[Reports].[Id] = @ReportId;
    END;