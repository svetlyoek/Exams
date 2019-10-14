CREATE TABLE Planes
(Id      INT
 PRIMARY KEY IDENTITY, 
 [Name]  NVARCHAR(30) NOT NULL, 
 [Seats] INT NOT NULL, 
 [Range] INT NOT NULL
);
CREATE TABLE Flights
(Id              INT
 PRIMARY KEY IDENTITY, 
 [DepartureTime] DATETIME2, 
 [ArrivalTime]   DATETIME2, 
 [Origin]        NVARCHAR(50) NOT NULL, 
 [Destination]   NVARCHAR(50) NOT NULL, 
 [PlaneId]       INT FOREIGN KEY REFERENCES Planes(Id) NOT NULL
);
CREATE TABLE Passengers
(Id           INT
 PRIMARY KEY IDENTITY, 
 [FirstName]  NVARCHAR(30) NOT NULL, 
 [LastName]   NVARCHAR(30) NOT NULL, 
 [Age]        INT NOT NULL, 
 [Address]    NVARCHAR(30) NOT NULL, 
 [PassportId] CHAR(11) NOT NULL
);
CREATE TABLE LuggageTypes
(Id     INT
 PRIMARY KEY IDENTITY, 
 [Type] NVARCHAR(30) NOT NULL
);
CREATE TABLE Luggages
(Id              INT
 PRIMARY KEY IDENTITY, 
 [LuggageTypeId] INT FOREIGN KEY REFERENCES LuggageTypes(Id) NOT NULL, 
 [PassengerId]   INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL
);
CREATE TABLE Tickets
(Id          INT
 PRIMARY KEY IDENTITY, 
 PassengerId INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL, 
 [FlightId]  INT FOREIGN KEY REFERENCES Flights(Id) NOT NULL, 
 [LuggageId] INT FOREIGN KEY REFERENCES Luggages(Id) NOT NULL, 
 [Price]     DECIMAL(15, 2) NOT NULL
);