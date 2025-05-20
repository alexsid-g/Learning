/*
Imagine you are a database engineer tasked with developing 
the SmartShop Inventory System for a fictional retail company, SmartShop. 
This system must manage inventory data across multiple stores, providing 
real-time insights into stock levels, sales trends, and supplier information.
*/

CREATE TABLE Products (
    ProductID INT PRIMARY KEY AUTO_INCREMENT,
    ProductName VARCHAR(100) NOT NULL,
    Category VARCHAR(50) NOT NULL,
    Price DECIMAL(10,2) NOT NULL,
    StockLevel INT NOT NULL
);

CREATE TABLE Stores (
    StoreID INT PRIMARY KEY AUTO_INCREMENT,
    StoreName VARCHAR(100) NOT NULL,
    Location VARCHAR(100)
);

CREATE TABLE Suppliers (
    SupplierID INT PRIMARY KEY AUTO_INCREMENT,
    SupplierName VARCHAR(100) NOT NULL,
    ContactInfo VARCHAR(100)
);

CREATE TABLE Inventory (
    InventoryID INT PRIMARY KEY AUTO_INCREMENT,
    StoreID INT NOT NULL,
    ProductID INT NOT NULL,
    StockLevel INT NOT NULL,
    FOREIGN KEY (StoreID) REFERENCES Stores(StoreID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

CREATE TABLE Sales (
    SaleID INT PRIMARY KEY AUTO_INCREMENT,
    StoreID INT NOT NULL,
    ProductID INT NOT NULL,
    Quantity INT NOT NULL,
    SaleDate DATETIME NOT NULL,
    FOREIGN KEY (StoreID) REFERENCES Stores(StoreID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

CREATE TABLE Deliveries (
    DeliveryID INT PRIMARY KEY AUTO_INCREMENT,
    SupplierID INT NOT NULL,
    DeliveryDate DATE NOT NULL,
    ExpectedDate DATE NOT NULL,
    FOREIGN KEY (SupplierID) REFERENCES Suppliers(SupplierID)
);

SELECT 
    ProductName, 
    Category, 
    Price, 
    StockLevel
FROM 
    Products;

    -- 1. Products in a specific category (replace 'Electronics' with your desired category)
SELECT 
    ProductName, 
    Category, 
    Price, 
    StockLevel
FROM 
    Products
WHERE 
    Category = 'Electronics';

-- 2. Products with low stock levels (e.g., less than 10)
SELECT 
    ProductName, 
    Category, 
    Price, 
    StockLevel
FROM 
    Products
WHERE 
    StockLevel < 10;

-- 3. Display products by Price in ascending order
SELECT 
    ProductName, 
    Category, 
    Price, 
    StockLevel
FROM 
    Products
ORDER BY 
    Price ASC;

-- 4. write the query to join the Products, Sales, and Suppliers tables.
SELECT
    p.ProductName,
    s.SaleDate,
    st.Location AS StoreLocation,
    s.Quantity AS UnitsSold
FROM
    Sales s
    JOIN Products p ON s.ProductID = p.ProductID
    JOIN Stores st ON s.StoreID = st.StoreID;

-- 5. nested queries and aggregation.
-- 5.0. Retrieve products with their total units sold using a nested subquery
SELECT 
    p.ProductName,
    p.Category,
    p.Price,
    p.StockLevel,
    (
        SELECT SUM(s.Quantity)
        FROM Sales s
        WHERE s.ProductID = p.ProductID
    ) AS TotalUnitsSold
FROM 
    Products p;
-- 5.1. Calculate total sales for each product
SELECT 
    p.ProductName,
    SUM(s.Quantity) AS TotalUnitsSold
FROM 
    Products p
    JOIN Sales s ON p.ProductID = s.ProductID
GROUP BY 
    p.ProductName;

-- 5.2. Identify suppliers with the most delayed deliveries
-- (Assuming you have a Deliveries table with columns: DeliveryID, SupplierID, DeliveryDate, ExpectedDate)
SELECT 
    sup.SupplierName,
    COUNT(*) AS DelayedDeliveries
FROM 
    Suppliers sup
    JOIN Deliveries d ON sup.SupplierID = d.SupplierID
WHERE 
    d.DeliveryDate > d.ExpectedDate
GROUP BY 
    sup.SupplierName
ORDER BY 
    DelayedDeliveries DESC;

-- 5.3. Use aggregate functions to analyze trends and summarize data
-- Average price of products by category
SELECT 
    Category,
    AVG(Price) AS AveragePrice
FROM 
    Products
GROUP BY 
    Category;

-- Maximum units sold in a single sale for each product
SELECT 
    p.ProductName,
    MAX(s.Quantity) AS MaxUnitsSoldInOneSale
FROM 
    Products p
    JOIN Sales s ON p.ProductID = s.ProductID
GROUP BY 
    p.ProductName;

-- Optimizations
CREATE INDEX idx_deliveries_supplierid ON Deliveries(SupplierID);
CREATE INDEX idx_deliveries_dates ON Deliveries(DeliveryDate, ExpectedDate);

-- Using a CTE to filter delayed deliveries first for better performance
WITH DelayedDeliveries AS (
    SELECT SupplierID
    FROM Deliveries
    WHERE DeliveryDate > ExpectedDate
)
SELECT 
    sup.SupplierName,
    COUNT(*) AS DelayedDeliveries
FROM 
    Suppliers sup
    JOIN DelayedDeliveries d ON sup.SupplierID = d.SupplierID
GROUP BY 
    sup.SupplierName
ORDER BY 
    DelayedDeliveries DESC;