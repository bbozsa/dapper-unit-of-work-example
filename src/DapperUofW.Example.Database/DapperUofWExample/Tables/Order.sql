CREATE TABLE [DapperUofWExample].[Order]
(
	[Id] UNIQUEIDENTIFIER NOT NULL, 
    [Description] NVARCHAR(250) NOT NULL, 
    [TotalAmount] INT NOT NULL, 
    [CustomerId] UNIQUEIDENTIFIER NOT NULL, 
    CONSTRAINT [PK_DapperUofWExample_Order] PRIMARY KEY CLUSTERED([Id] ASC), 
    CONSTRAINT [FK_DapperUofWExample_Order_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [DapperUofWExample].[Customer]([Id]) ON DELETE CASCADE 
)
