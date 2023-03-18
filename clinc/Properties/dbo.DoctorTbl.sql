CREATE TABLE [dbo].[DoctorTbl] (
    [DocId]    INT           IDENTITY (1, 1) NOT NULL,
    [DocName]  VARCHAR (100) NOT NULL,
    [DocDOF]   DATE          NOT NULL,
    [DocGen]   VARCHAR (10)  NOT NULL,
    [DocSpec]  VARCHAR (50)  NOT NULL,
    [DocEXP]   INT           NOT NULL,
    [DocPhone] VARCHAR (15)  NOT NULL,
    [DocAdd]   VARCHAR (100) NOT NULL,
    [DocPass]  VARCHAR (10)  NOT NULL,
    PRIMARY KEY CLUSTERED ([DocId] ASC)
);

