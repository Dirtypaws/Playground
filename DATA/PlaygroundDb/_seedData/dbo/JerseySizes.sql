SET IDENTITY_INSERT [dbo].[JerseySize] ON

MERGE INTO  [dbo].[JerseySize] AS t
USING ( VALUES
	(1, N'S', 'Small'),
	(2, N'M', 'Medium'),
	(3, N'L', 'Large'),
	(4, N'XL', 'X-Large'),
	(5, N'2XL', 'XX-Large'),
	(6, N'3XL', 'XXX-Large'),
	(7, N'G', 'Goalie')
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

SET IDENTITY_INSERT  [dbo].[JerseySize] OFF