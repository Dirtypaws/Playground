CREATE TABLE [roster].[Images] (
    [Id]       INT             IDENTITY (1, 1) NOT NULL,
    [PlayerId] INT             NOT NULL,
    [Url]      NVARCHAR (1024) NULL,
    [Size]     NVARCHAR (32)   NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Images_To_PlayerId] FOREIGN KEY ([PlayerId]) REFERENCES [roster].[Player] ([Id])
);

