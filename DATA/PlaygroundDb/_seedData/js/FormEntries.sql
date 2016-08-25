SET IDENTITY_INSERT [js].[FormEntry] ON

MERGE INTO  [js].[FormEntry] AS t
USING( VALUES
(1, 1, NULL, NULL, NULL, NULL, NULL, NULL, N'{"name":"Boris Momtchev","age":41,"favorite_color":"#ffa500","gender":"male"}', N'2016-08-24 16:29:13', N'anonymous', N'anonymous', N'2016-08-24 16:29:13'),
(2, 1, NULL, NULL, NULL, NULL, NULL, NULL, N'{"name":"Matt Krizanac","age":32,"favorite_color":"#e0bcd7","gender":"male"}', N'2016-08-24 16:29:43', N'anonymous', N'anonymous', N'2016-08-24 16:29:43'),
(3, 2, NULL, NULL, NULL, NULL, NULL, NULL, N'{"street":"100 Main St","zip":41000,"apt":"100","state":"MN"}', N'2016-08-24 16:30:06', N'anonymous', N'anonymous', N'2016-08-24 16:30:06'),
(4, 2, NULL, NULL, NULL, NULL, NULL, NULL, N'{"street":"200 Wall St","zip":10123,"apt":"","state":"NY"}', N'2016-08-24 16:30:38', N'anonymous', N'anonymous', N'2016-08-24 16:30:38'),
(5, 2, NULL, NULL, NULL, NULL, NULL, NULL, N'{"street":"12 Crazy St NE","zip":45000,"apt":"","state":"MN"}', N'2016-08-24 16:30:57', N'anonymous', N'anonymous', N'2016-08-24 16:30:57')
) AS s ([Id], [FormId], [WorkspaceId], [OverlayId], [LayerId], [DrawingId], [LayerName], [FeatureName], [Content], [CreatedOn], [CreatedBy], [User], [TS])
	ON [t].[ID] = [s].[ID]
WHEN MATCHED THEN
	UPDATE SET
		[t].[FormId] = [s].[FormId],
		[t].[WorkspaceId] = [s].[WorkspaceId],
		[t].[OverlayId] = [s].[OverlayId],
		[t].[LayerId] = [s].[LayerId],
		[t].[DrawingId] = [s].[DrawingId],
		[t].[LayerName] = [s].[LayerName],
		[t].[FeatureName] = [s].[FeatureName],
		[t].[Content] = [s].[Content],
		[t].[CreatedOn] = [s].[CreatedOn],
		[t].[CreatedBy] = [s].[CreatedBy],
		[t].[User] = [s].[User],
		[t].[TS] = [s].[TS]
WHEN NOT MATCHED BY TARGET THEN
	INSERT ([Id], [FormId], [WorkspaceId], [OverlayId], [LayerId], [DrawingId], [LayerName], [FeatureName], [Content], [CreatedOn], [CreatedBy], [User], [TS])
	VALUES ([s].[Id], [s].[FormId], [s].[WorkspaceId], [s].[OverlayId], [s].[LayerId], [s].[DrawingId], [s].[LayerName], [s].[FeatureName], [s].[Content], [s].[CreatedOn], [s].[CreatedBy], [s].[User], [s].[TS])
WHEN NOT MATCHED BY SOURCE THEN
	DELETE;

SET IDENTITY_INSERT [js].[FormEntry] OFF