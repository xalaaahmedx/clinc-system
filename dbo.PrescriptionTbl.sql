CREATE TABLE [dbo].[PrescriptionTbl] (
    [PrescId]     INT          IDENTITY (500, 1) NOT NULL,
    [DocId]       INT          NOT NULL,
    [DocName]     VARCHAR (50) NOT NULL,
    [PatId]       INT          NOT NULL,
    [PatName]     VARCHAR (50) NOT NULL,
    [LabTestId]   INT          NOT NULL,
    [LabTestName] VARCHAR (50) NOT NULL,
    [Medicines]   VARCHAR (50) NOT NULL,
    [Cost]        INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([PrescId] ASC),
    CONSTRAINT [FK1] FOREIGN KEY ([DocId]) REFERENCES [dbo].[DoctorTbl] ([DocId]),
    CONSTRAINT [FK2] FOREIGN KEY ([PatId]) REFERENCES [dbo].[PatientTbl] ([PatId]),
    CONSTRAINT [FK3] FOREIGN KEY ([LabTestId]) REFERENCES [dbo].[TestTbl] ([TestNum])
);

