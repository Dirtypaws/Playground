CREATE TABLE [roster].[Email] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [PlayerId]      INT            NOT NULL,
    [ContactTypeId] INT            NOT NULL,
    [Address]       NVARCHAR (255) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Email_To_ContactTypeId] FOREIGN KEY ([ContactTypeId]) REFERENCES [dbo].[ContactType] ([Id]),
    CONSTRAINT [FK_Email_To_PlayerId] FOREIGN KEY ([PlayerId]) REFERENCES [roster].[Player] ([Id])
);

