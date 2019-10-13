SELECT i.Id, 
       concat(u.Username, ' : ', i.Title) AS [IssueAssignee]
FROM Users AS u
     JOIN Issues AS i ON u.Id = i.AssigneeId
ORDER BY i.Id DESC, 
         [IssueAssignee] ASC;