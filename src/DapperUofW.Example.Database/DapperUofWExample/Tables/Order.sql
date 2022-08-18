CREATE TABLE [DapperUofWExample].[Order]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Description] NVARCHAR(250) NOT NULL, 
    [TotalAmount] INT NOT NULL, 
    [CustomerId] UNIQUEIDENTIFIER NOT NULL
)
