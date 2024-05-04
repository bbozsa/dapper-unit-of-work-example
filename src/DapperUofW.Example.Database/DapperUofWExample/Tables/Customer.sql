CREATE TABLE [DapperUofWExample].[Customer]
(
	[Id] UNIQUEIDENTIFIER NOT NULL, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [Email] NVARCHAR(250) NOT NULL, 
    [ConcurrencyToken] ROWVERSION NOT NULL, 
    CONSTRAINT [PK_DapperUofWExample_Customer] PRIMARY KEY CLUSTERED ([Id] ASC)
)
