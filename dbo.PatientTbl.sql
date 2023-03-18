CREATE TABLE [dbo].[PatientTbl] (
    [PatId]    INT           IDENTITY (100, 1) NOT NULL,
    [PatName]  VARCHAR (50)  NOT NULL,
    [PatGen]   VARCHAR (10)  NOT NULL,
    [PatDOB]   DATE          NOT NULL,
    [PatAdd]   VARCHAR (100) NOT NULL,
    [PatPhone] VARCHAR (15)  NOT NULL,
    [Pathiv]   VARCHAR (10)  NOT NULL,
    [Patall]   NCHAR (100)   NOT NULL,
    PRIMARY KEY CLUSTERED ([PatId] ASC)
);

