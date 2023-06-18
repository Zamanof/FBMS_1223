-- One to One
--CREATE TABLE Countries(
--[Id] int PRIMARY KEY IDENTITY(1, 1),
--[Name] nvarchar(50)
--)

--CREATE TABLE Capitals(
--[Id] int PRIMARY KEY IDENTITY(1, 1),
--[Name] nvarchar(50),
--CountryId int REFERENCES Countries(Id),
--UNIQUE(CountryId)
--)

--INSERT INTO Countries
--VALUES 
--('Azerbijan'), 
--('Turkey') ,
--('Pakistan'),
--('Ukraine')

--INSERT INTO Capitals
--VALUES 
--('Baku', 1), 
--('Ankara', 2) ,
--('Islamabad', 3),
--('Kiev', 4)


-- One to Many
--CREATE TABLE Categories(
--[Id] int PRIMARY KEY IDENTITY(1, 1),
--[Name] nvarchar(50)
--)

--CREATE TABLE Products(
--[Id] int PRIMARY KEY IDENTITY(1, 1),
--[Name] nvarchar(50),
--CategoryId int REFERENCES Categories(Id)
--)

--INSERT INTO Categories
--VALUES 
--('Cake'),
--('Food')

--INSERT INTO Products
--VALUES 
--('Napoleon', 1),
--('Muffin', 1),
--('Shekies halva', 1),
--('Magnoliya', 1),
--('Roll Kebab', 2),
--('Slice Kebab', 2),
--('Burial Kebab', 2),
--('TomatoesEgg', 2)

--SELECT C.[Id], C.[Name], P.[Id], P.[Name], P.CategoryId
--                            FROM Categories AS C
--                            INNER JOIN Products AS P
--                            ON C.Id = P.CategoryId




-- Many to Many
--CREATE TABLE Authors(
--Id int PRIMARY KEY IDENTITY(1,1),
--[Name] nvarchar(50)
--)

--CREATE TABLE Books(
--Id int PRIMARY KEY IDENTITY(1,1),
--[Name] nvarchar(50),
--Price decimal
--)


--CREATE TABLE AuthorBook(
--AuthorId  int REFERENCES Authors(Id),
--BookId int REFERENCES Books(Id),
--CONSTRAINT PK_AuthorBook PRIMARY KEY (AuthorId, BookId)
--)





--INSERT INTO Authors 
--VALUES
--('Author1'),
--('Author2'),
--('Author3')

--INSERT INTO Books 
--VALUES
--('Book1', 10),
--('Book2', 12),
--('Book3', 15),
--('Book4', 27),
--('Book5', 22)

--INSERT INTO AuthorBook 
--VALUES
--(1,1),(1,2),(2,2),(2,3),(3,4),(3,5)