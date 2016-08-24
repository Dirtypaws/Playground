CREATE TABLE [dbo].[Form] (
    [Id]          INT             IDENTITY (1, 1) NOT NULL,
    [eFormTypeId] INT             NOT NULL,
    [Name]        NVARCHAR (256)  NOT NULL,
    [Code]        NVARCHAR (256)  NULL,
    [Description] NVARCHAR (1024) NULL,
    [Schema]      NVARCHAR (MAX)  NOT NULL,
    [IsActive]    BIT             NOT NULL,
    [Version]     VARCHAR (50)    NOT NULL,
    [CreatedOn]   DATETIME2 (7)   NOT NULL,
    [CreatedBy]   NVARCHAR (128)  NOT NULL,
    [User]        NVARCHAR (128)  NOT NULL,
    [TS]          DATETIME2 (7)   NULL,
    CONSTRAINT [PK_Form] PRIMARY KEY CLUSTERED ([Id] ASC)
);