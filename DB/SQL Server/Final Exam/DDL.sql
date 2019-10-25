CREATE TABLE Users
(Id          INT
 PRIMARY KEY IDENTITY, 
 [Username]  VARCHAR(30)
 UNIQUE NOT NULL, 
 [Password]  VARCHAR(50) NOT NULL, 
 [Name]      VARCHAR(50), 
 [Birthdate] DATETIME, 
 [Age]       INT CHECK(Age BETWEEN 14 AND 110), 
 [Email]     VARCHAR(50) NOT NULL
);
CREATE TABLE Departments
(Id     INT
 PRIMARY KEY IDENTITY, 
 [Name] VARCHAR(50) NOT NULL
);
CREATE TABLE Employees
(Id             INT
 PRIMARY KEY IDENTITY, 
 [FirstName]    VARCHAR(25), 
 [LastName]     VARCHAR(25), 
 [Birthdate]    DATETIME, 
 [Age]          INT CHECK(Age BETWEEN 18 AND 110), 
 [DepartmentId] INT FOREIGN KEY REFERENCES Departments(Id)
);
CREATE TABLE Categories
(Id           INT
 PRIMARY KEY IDENTITY, 
 [Name]       VARCHAR(50) NOT NULL, 
 DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL
);
CREATE TABLE [Status]
(Id      INT
 PRIMARY KEY IDENTITY, 
 [Label] VARCHAR(30) NOT NULL
);
CREATE TABLE Reports
(Id            INT
 PRIMARY KEY IDENTITY, 
 CategoryId    INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL, 
 StatusId      INT FOREIGN KEY REFERENCES [Status](Id) NOT NULL, 
 OpenDate      DATETIME NOT NULL, 
 CloseDate     DATETIME, 
 [Description] CHAR(200) NOT NULL, 
 UserId        INT FOREIGN KEY REFERENCES Users(Id) NOT NULL, 
 EmployeeId    INT FOREIGN KEY REFERENCES Employees(Id)
);