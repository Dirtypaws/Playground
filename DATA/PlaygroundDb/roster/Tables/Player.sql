CREATE TABLE [roster].[Player] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    [SlackId]        NVARCHAR (64)  NULL,
    [Number]         INT            NULL,
    [PracticeNumber] INT            NULL,
    [JerseySizeId]   INT            NULL,
    [JerseyPaid]     BIT            DEFAULT ((0)) NOT NULL,
    [Handedness]     CHAR (1)       NULL,
    [PositionId]     INT            NULL,
    [FirstName]      NVARCHAR (32)  NULL,
    [LastName]       NVARCHAR (32)  NULL,
    [LastLogin]      DATETIME2 (7)  NULL,
    [Skype]          NVARCHAR (256) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Player_To_JerseySizeId] FOREIGN KEY ([JerseySizeId]) REFERENCES [dbo].[JerseySize] ([Id]),
    CONSTRAINT [FK_Player_To_PositionId] FOREIGN KEY ([PositionId]) REFERENCES [dbo].[Position] ([Id])
);

