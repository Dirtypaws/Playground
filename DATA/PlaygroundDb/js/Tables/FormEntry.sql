CREATE TABLE [js].[FormEntry] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [FormId]      INT            NOT NULL,
    [WorkspaceId] INT            NULL,
    [OverlayId]   INT            NULL,
    [LayerId]     INT            NULL,
    [DrawingId]   INT            NULL,
    [LayerName]   NVARCHAR (512) NULL,
    [FeatureName] NVARCHAR (512) NULL,
    [Content]     NVARCHAR (MAX) NOT NULL,
    [CreatedOn]   DATETIME2 (7)  NOT NULL,
    [CreatedBy]   NVARCHAR (128) NOT NULL,
    [User]        NVARCHAR (128) NOT NULL,
    [TS]          DATETIME2 (7)  NULL,
    CONSTRAINT [PK_FormEntries] PRIMARY KEY CLUSTERED ([Id] ASC)
);