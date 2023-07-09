BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;
            IF NOT EXISTS (SELECT * FROM [sys].[objects]  
            WHERE object_id = OBJECT_ID(N'[DapperUofWExample].[Customer]') AND type in (N'U'))
                BEGIN
                    CREATE TABLE [InventoryTracker].[User] (
                        [Id]                  UNIQUEIDENTIFIER NOT NULL,
                        [IdentityProviderId]  NVARCHAR (50) NULL,
                        [FirstName]           NVARCHAR (50)   NULL,
                        [LastName]            NVARCHAR (50)   NULL,
                        [Email]               NVARCHAR (250)   NOT NULL,
                        [IsVerified]          BIT              NOT NULL,
                        [ConcurrencyToken]    UNIQUEIDENTIFIER NOT NULL,
                        CONSTRAINT [PK_User] PRIMARY KEY ([Id]),
                    );


                    CREATE TABLE [DapperUofWExample].[Customer] (
	                    [Id] INT NOT NULL PRIMARY KEY, 
                        [FirstName] NVARCHAR(50) NOT NULL, 
                        [LastName] NVARCHAR(50) NOT NULL, 
                        [Email] NVARCHAR(250) NOT NULL
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
