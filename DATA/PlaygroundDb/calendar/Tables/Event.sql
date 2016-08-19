CREATE TABLE [calendar].[Event] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [EventTypeId] INT            NOT NULL,
    [StartTime]   DATETIME2 (7)  NOT NULL,
    [EndTime]     DATETIME2 (7)  NULL,
    [Opponent]    NVARCHAR (128) NULL,
    [IsHome]      BIT            NULL,
    [Url]         NVARCHAR (256) NULL,
    [Location]    NVARCHAR (512) NULL,
    [Cost]        MONEY          NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Event_To_EventTypeId] FOREIGN KEY ([EventTypeId]) REFERENCES [dbo].[EventType] ([Id])
);

