CREATE TABLE [roster].[Phone] (
    [Id]            INT           IDENTITY (1, 1) NOT NULL,
    [PlayerId]      INT           NOT NULL,
    [ContactTypeId] INT           NOT NULL,
    [Number]        NVARCHAR (32) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Phone_To_ContactTypeId] FOREIGN KEY ([ContactTypeId]) REFERENCES [dbo].[ContactType] ([Id]),
    CONSTRAINT [FK_Phone_To_PlayerId] FOREIGN KEY ([PlayerId]) REFERENCES [roster].[Player] ([Id])
);

