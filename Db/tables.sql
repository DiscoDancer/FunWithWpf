CREATE TABLE Customers
(
	ID_Customer INT NOT NULL IDENTITY PRIMARY KEY,
	FirstName nvarchar(20) NOT NULL,
	MiddleName nvarchar(20) NOT NULL,
	LastName nvarchar(20) NOT NULL,
	[Address] nvarchar(50),
	City nvarchar(20),
	Phone char(11)
);

CREATE TABLE Employees
(
	ID_Employee INT NOT NULL IDENTITY PRIMARY KEY,
	FirstName nvarchar(20) NOT NULL,
	MiddleName nvarchar(20) NOT NULL,
	LastName nvarchar(20) NOT NULL,
	Position nvarchar(25),
	Salary money,
	PriorSalary  money,
	Phone char(11)
);

CREATE TABLE Products
(
	ID_Product int NOT NULL IDENTITY PRIMARY KEY,
	[Name] nvarchar(50) NOT NULL,
	Color nchar(20),
	[Description] nvarchar(max)
);

CREATE TABLE Orders
(
	ID_Order int NOT NULL IDENTITY PRIMARY KEY,
	CustomerID int NOT NULL,
	EmployeeID int NOT NULL,
	ProductID int NOT NULL,
	Quantity int NOT NULL,
	Price money NOT NULL,
	OrderDate date DEFAULT GETDATE(),
	CONSTRAINT FK_CustomerID FOREIGN KEY (CustomerID)     
    	REFERENCES Customers (ID_Customer)     
    	ON DELETE CASCADE    
    	ON UPDATE CASCADE,
    CONSTRAINT FK_EmployeeID FOREIGN KEY (EmployeeID)     
    	REFERENCES Employees (ID_Employee)     
    	ON DELETE CASCADE    
    	ON UPDATE CASCADE,
    CONSTRAINT FK_ProductID FOREIGN KEY (ProductID)     
    	REFERENCES Products (ID_Product)     
    	ON DELETE CASCADE    
    	ON UPDATE CASCADE
);

ALTER TABLE Customers
ADD
CHECK (Phone LIKE '[8][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]');

ALTER TABLE Employees
ADD
CHECK (Phone LIKE '[8][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]');

ALTER TABLE Employees
ADD
CHECK(PriorSalary < Salary);

ALTER TABLE Orders
ADD
CHECK (OrderDate >= DATEADD(DAY, -90, GETDATE()) AND OrderDate <= GETDATE());

