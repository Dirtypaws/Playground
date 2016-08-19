SET IDENTITY_INSERT [dbo].[EventType] ON

MERGE INTO  [dbo].[EventType] AS t
USING ( VALUES
	(1, N'Practice', 'Practice'),
	(2, N'Develop', 'Developmental Ice'),
	(3, N'Pickup', 'Pick-up Hockey'),
	(4, N'Game', 'Game'),
	(5, N'Team', 'Team Event')
) AS s ([ID], [Key], [Name])
	ON [t].[ID] = [s].[ID]
WHEN MATCHED AND (s.[Name] <> t.[Name] AND s.[Key] <> t.[Key]) THEN
	UPDATE SET
		t.[Name] = [s].[Name],
		t.[Key] = [s].[Key],
		t.[Usr] = 'system'
WHEN NOT MATCHED BY TARGET THEN
	INSERT ([ID], [Name], [Key], [Usr], [TS])
	VALUES (s.[ID], s.[Name], s.[Key], 'system', GETUTCDATE())
WHEN NOT MATCHED BY SOURCE THEN
	DELETE;

SET IDENTITY_INSERT  [dbo].[EventType] OFF
