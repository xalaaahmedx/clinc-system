CREATE TABLE [dbo].[TestTbl] (
    [TestNum]  INT          IDENTITY (2000, 1) NOT NULL,
    [TestName] VARCHAR (50) NOT NULL,
    [TestCost] INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([TestNum] ASC)
);

