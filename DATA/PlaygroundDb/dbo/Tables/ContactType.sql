CREATE TABLE [dbo].[ContactType] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Key]  NVARCHAR (16)  NOT NULL,
    [Name] NVARCHAR (128) NULL,
    [Usr]  NVARCHAR (128) NOT NULL,
    [TS]   DATETIME2 (7)  NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

