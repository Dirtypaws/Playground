SET IDENTITY_INSERT [dbo].[Position] ON

MERGE INTO  [dbo].[Position] AS t
USING ( VALUES
	(1, N'LW', 'Left Wing'),
	(2, N'RW', 'Right Wing'),
	(3, N'C', 'Center'),
	(4, N'LD', 'Left Defenseman'),
	(5, N'RD', 'Right Defenseman'),
	(6, N'G', 'Goalie'),
	(7, N'COACH', 'Coach')
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

SET IDENTITY_INSERT  [dbo].[Position] OFF
