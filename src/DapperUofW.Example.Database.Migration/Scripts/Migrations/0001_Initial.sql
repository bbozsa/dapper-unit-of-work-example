BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;
            IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'DbUp')
	            BEGIN
		            EXEC('CREATE SCHEMA [DbUp]');
	            END;

            IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'DapperUofWExample')
                BEGIN
                     EXEC('CREATE SCHEMA [DapperUofWExample]');
                END;

            IF NOT EXISTS (SELECT * FROM [sys].[objects]  
            WHERE object_id = OBJECT_ID(N'[DapperUofWExample].[Customer]') AND type in (N'U'))
                BEGIN
                    CREATE TABLE [DapperUofWExample].[Customer]
                    (
	                	[Id] UNIQUEIDENTIFIER NOT NULL, 
                        [FirstName] NVARCHAR(50) NOT NULL, 
                        [LastName] NVARCHAR(50) NOT NULL, 
                        [Email] NVARCHAR(250) NOT NULL, 
                        [ConcurrencyToken] ROWVERSION NOT NULL, 
                        CONSTRAINT [PK_DapperUofWExample_Customer] PRIMARY KEY CLUSTERED ([Id] ASC)
                    );
                END

            IF NOT EXISTS (SELECT * FROM [sys].[objects]  
            WHERE object_id = OBJECT_ID(N'[DapperUofWExample].[Order]') AND type in (N'U'))
                BEGIN
                    CREATE TABLE [DapperUofWExample].[Order]
                    (
	                    [Id] UNIQUEIDENTIFIER NOT NULL, 
                        [Description] NVARCHAR(250) NOT NULL, 
                        [TotalAmount] INT NOT NULL, 
                        [CustomerId] UNIQUEIDENTIFIER NOT NULL, 
                        CONSTRAINT [PK_DapperUofWExample_Order] PRIMARY KEY CLUSTERED([Id] ASC), 
                        CONSTRAINT [FK_DapperUofWExample_Order_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [DapperUofWExample].[Customer]([Id]) ON DELETE CASCADE 
                    );
                END
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH 
        -- Test if the transaction is uncommittable.  
        IF (XACT_STATE()) = -1  
            BEGIN  
                ROLLBACK TRANSACTION;  
                RAISERROR (N'The transaction is in an uncommittable state. Rolling back transaction.', 18 , 1);
            END;  
        
        -- Test if the transaction is committable.  
        IF (XACT_STATE()) = 1  
            BEGIN  
                PRINT N'The transaction is committable. Committing transaction.'  
                COMMIT TRANSACTION;     
            END;  
    END CATCH
END; 
