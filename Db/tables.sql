DROP TABLE IF EXISTS Orders;
DROP TABLE IF EXISTS Customers;
DROP TABLE IF EXISTS Employees;
DROP TABLE IF EXISTS Products;
DROP TABLE IF EXISTS ProductCategories;
DROP TABLE IF EXISTS ProductCategory;
DROP TABLE IF EXISTS Logs;

CREATE TABLE Logs
(
	LogID INT NOT NULL IDENTITY PRIMARY KEY,
	LogText nvarchar(100) NOT NULL,
	LogDate datetime DEFAULT GETDATE()
);

CREATE TABLE Customers
(
	CustomerID INT NOT NULL IDENTITY PRIMARY KEY,
	FirstName nvarchar(20) NOT NULL,
	MiddleName nvarchar(20) NOT NULL,
	LastName nvarchar(20) NOT NULL,
	[Address] nvarchar(50),
	City nvarchar(20),
	Phone char(11)
);

CREATE TABLE Employees
(
	EmployeeID INT NOT NULL IDENTITY PRIMARY KEY,
	FirstName nvarchar(20) NOT NULL,
	MiddleName nvarchar(20) NOT NULL,
	LastName nvarchar(20) NOT NULL,
	Position nvarchar(25),
	Salary money,
	PriorSalary  money,
	Phone char(11)
);

CREATE TABLE ProductCategories
(
	CategoryID INT NOT NULL IDENTITY PRIMARY KEY,
	[Name] varchar(100) NOT NULL
);

CREATE TABLE Products
(
	ProductID int NOT NULL IDENTITY PRIMARY KEY,
	CategoryID INT NOT NULL,
	[Name] nvarchar(50) NOT NULL,
	Color nchar(20),
	[Description] nvarchar(max),
	CONSTRAINT FK_CategoryID FOREIGN KEY (CategoryID)     
    	REFERENCES ProductCategories (CategoryID)     
    	ON DELETE CASCADE    
    	ON UPDATE CASCADE
);

CREATE TABLE Orders
(
	OrderID int NOT NULL IDENTITY PRIMARY KEY,
	CustomerID int NOT NULL,
	EmployeeID int NOT NULL,
	ProductID int NOT NULL,
	Quantity int NOT NULL,
	Price money NOT NULL,
	OrderDate date DEFAULT GETDATE(),
	CONSTRAINT FK_CustomerID FOREIGN KEY (CustomerID)     
    	REFERENCES Customers (CustomerID)     
    	ON DELETE CASCADE    
    	ON UPDATE CASCADE,
    CONSTRAINT FK_EmployeeID FOREIGN KEY (EmployeeID)     
    	REFERENCES Employees (EmployeeID)     
    	ON DELETE CASCADE    
    	ON UPDATE CASCADE,
    CONSTRAINT FK_ProductID FOREIGN KEY (ProductID)     
    	REFERENCES Products (ProductID)     
    	ON DELETE CASCADE    
    	ON UPDATE CASCADE
);

DBCC CHECKIDENT (ProductCategories, RESEED, 1);
DBCC CHECKIDENT (Products, RESEED, 1);
DBCC CHECKIDENT (Customers, RESEED, 1);
DBCC CHECKIDENT (Employees, RESEED, 1);
DBCC CHECKIDENT (Orders, RESEED, 1);
DBCC CHECKIDENT (Logs, RESEED, 1);