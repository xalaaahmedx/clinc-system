CREATE TABLE [dbo].[ReceptionistTbl] (
    [RecepId]    INT           IDENTITY (800, 1) NOT NULL,
    [RecepName]  VARCHAR (50)  NOT NULL,
    [RecepPhone] VARCHAR (15)  NOT NULL,
    [RecepPass]  VARCHAR (10)  NOT NULL,
    [RecepAdd]   VARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([RecepId] ASC)
);

