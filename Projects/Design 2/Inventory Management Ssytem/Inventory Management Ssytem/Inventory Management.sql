-- Create the database
CREATE DATABASE IF NOT EXISTS InventoryManagement;

-- Use the database
USE InventoryManagement;

-- Create Products Table
CREATE TABLE Products (
    ProductID INT PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(100) NOT NULL,
    SKU VARCHAR(50) UNIQUE NOT NULL,
    Category VARCHAR(50) NULL,
    Quantity INT DEFAULT 0,
    UnitPrice DECIMAL(10, 2) NULL,
    Barcode VARCHAR(50) NULL,
    CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);

-- Create Suppliers Table
CREATE TABLE Suppliers (
    SupplierID INT PRIMARY KEY AUTO_INCREMENT,
    SupplierName VARCHAR(100) NOT NULL,
    ContactName VARCHAR(100) NULL,
    Phone VARCHAR(15) NULL,
    Email VARCHAR(100) NULL,
    Address VARCHAR(255) NULL
);

-- Create PurchaseOrders Table
CREATE TABLE PurchaseOrders (
    PurchaseOrderID INT PRIMARY KEY AUTO_INCREMENT,
    SupplierID INT,
    OrderDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    Status VARCHAR(20) CHECK (Status IN ('Pending', 'Completed', 'Cancelled')),
    TotalAmount DECIMAL(10, 2) NULL,
    FOREIGN KEY (SupplierID) REFERENCES Suppliers(SupplierID)
);

-- Create PurchaseOrderDetails Table
CREATE TABLE PurchaseOrderDetails (
    PODetailID INT PRIMARY KEY AUTO_INCREMENT,
    PurchaseOrderID INT,
    ProductID INT,
    Quantity INT NOT NULL,
    UnitPrice DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (PurchaseOrderID) REFERENCES PurchaseOrders(PurchaseOrderID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- Create SalesOrders Table
CREATE TABLE SalesOrders (
    SalesOrderID INT PRIMARY KEY AUTO_INCREMENT,
    CustomerName VARCHAR(100) NULL,
    OrderDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    Status VARCHAR(20) CHECK (Status IN ('Pending', 'Shipped', 'Cancelled')),
    TotalAmount DECIMAL(10, 2) NULL
);

-- Create SalesOrderDetails Table
CREATE TABLE SalesOrderDetails (
    SODetailID INT PRIMARY KEY AUTO_INCREMENT,
    SalesOrderID INT,
    ProductID INT,
    Quantity INT NOT NULL,
    UnitPrice DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (SalesOrderID) REFERENCES SalesOrders(SalesOrderID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- Create StockMovements Table
CREATE TABLE StockMovements (
    MovementID INT PRIMARY KEY AUTO_INCREMENT,
    ProductID INT,
    MovementType VARCHAR(20) CHECK (MovementType IN ('IN', 'OUT', 'ADJUSTMENT')),
    Quantity INT NOT NULL,
    MovementDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    Description VARCHAR(255) NULL,
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- Create Users Table
CREATE TABLE Users (
    UserID INT PRIMARY KEY AUTO_INCREMENT,
    Username VARCHAR(50) UNIQUE NOT NULL,
    PasswordHash VARCHAR(255) NOT NULL,
    Role VARCHAR(20) CHECK (Role IN ('Admin', 'Manager', 'Staff')),
    CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP
);

-- Create AuditLogs Table
CREATE TABLE AuditLogs (
    LogID INT PRIMARY KEY AUTO_INCREMENT,
    UserID INT,
    Action VARCHAR(100) NOT NULL,
    TableAffected VARCHAR(50) NULL,
    ActionTime DATETIME DEFAULT CURRENT_TIMESTAMP,
    Description VARCHAR(255) NULL,
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

-- Create Categories Table
CREATE TABLE Categories (
    CategoryID INT PRIMARY KEY AUTO_INCREMENT,
    CategoryName VARCHAR(100) UNIQUE NOT NULL,
    Description VARCHAR(255) NULL
);