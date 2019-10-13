CREATE TABLE Users
(Id         INT
 PRIMARY KEY IDENTITY, 
 [Username] NVARCHAR(30) NOT NULL, 
 [Password] NVARCHAR(30) NOT NULL, 
 [Email]    NVARCHAR(50) NOT NULL
);
CREATE TABLE Repositories
(Id     INT
 PRIMARY KEY IDENTITY, 
 [Name] NVARCHAR(50) NOT NULL
);
CREATE TABLE RepositoriesContributors
(RepositoryId  INT FOREIGN KEY REFERENCES Repositories(Id) NOT NULL, 
 ContributorId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL, 
 PRIMARY KEY(RepositoryId, ContributorId)
);
CREATE TABLE Issues
(Id             INT
 PRIMARY KEY IDENTITY, 
 [Title]        NVARCHAR(255) NOT NULL, 
 [IssueStatus]  CHAR(6) NOT NULL, 
 [RepositoryId] INT FOREIGN KEY REFERENCES Repositories(Id) NOT NULL, 
 [AssigneeId]   INT FOREIGN KEY REFERENCES Users(Id) NOT NULL
);
CREATE TABLE Commits
(Id              INT
 PRIMARY KEY IDENTITY NOT NULL, 
 [Message]       NVARCHAR(255) NOT NULL, 
 [IssueId]       INT FOREIGN KEY REFERENCES Issues(Id), 
 [RepositoryId]  INT FOREIGN KEY REFERENCES Repositories(Id) NOT NULL, 
 [ContributorId] INT FOREIGN KEY REFERENCES Users(Id) NOT NULL
);
CREATE TABLE Files
(Id         INT
 PRIMARY KEY IDENTITY, 
 [Name]     NVARCHAR(100) NOT NULL, 
 [Size]     DECIMAL(15, 2) NOT NULL, 
 [ParentId] INT FOREIGN KEY REFERENCES Files(Id), 
 [CommitId] INT FOREIGN KEY REFERENCES Commits(Id) NOT NULL
);
