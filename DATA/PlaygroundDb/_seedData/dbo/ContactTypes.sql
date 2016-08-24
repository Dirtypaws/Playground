SET IDENTITY_INSERT [dbo].[ContactType] ON

MERGE INTO  [dbo].[ContactType] AS t
USING ( VALUES
	(1, N'Primary', 'Primary'),
	(2, N'Secondary', 'Secondary'),
	(3, N'Emergency', 'Emergency'),
	(4, N'Other', 'Other')
) AS s ([ID], [Name], [Key])
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

SET IDENTITY_INSERT  [dbo].[ContactType] OFF
