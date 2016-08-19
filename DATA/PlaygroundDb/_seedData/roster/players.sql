SET IDENTITY_INSERT [roster].[Player] ON

MERGE INTO  [roster].[Player] AS t
USING ( VALUES
	(1, 3, N'Raymond', 'Schroeder', 21, 'L', 3, 4, 1),
	(2, 11, N'Donna', 'Pate', 12, 'R', 3, 3, 1),
	(3, 37, N'Velma', 'Greer', 19, 'R', 2, 3, 1),
	(4, 31, N'Ronan', 'Melton', 1, NULL, 6, 7, 0),
	(5, 26, N'Phelan', 'Cherry', 9, 'R', 2, 3, 1),
	(6, 23, N'Flynn', 'Richard', 4, 'L', 3, 3, 1),
	(7, 15, N'Nathan', 'Bentley', 22, 'L', 1, 3, 1),
	(8, 10, N'Dylan', 'Kline', 10, 'L', 4, 3, 1),
	(9, 75, N'Mark', 'Oneill', 2, 'R', 2, 5, 1),
	(10, 45, N'Solomon', 'Harrington', 3, 'L', 4, 3, 0),
	(11, 20, N'Melyssa', 'Saunders', 7, 'L', 1, 3, 1),
	(12, 44, N'Uta', 'Leblanc', 14, 'R', 1, 3, 1),
	(13, 19, N'Delilah', 'Douglas', 6, 'R', 5, 3, 1),
	(14, 18, N'Buffy', 'Roy', 8, 'R', 5, 3, 1),
	(15, 55, N'Irma', 'Leon', 5, 'L', 1, 2, 1),
	(16, 6, N'Gay', 'Rodriguez', 11, 'L', 4, 3, 1),
	(17, 13, N'Igor', 'Ward', 13, 'R', 5, 3, 0),
	(18, 28, N'Elmo', 'Bishop', 17, 'R', 2, 5, 1),
	(19, NULL, N'Demetrius', 'Forbes', NULL, NULL, NULL, NULL, 1),
	(20, NULL, N'Amal', 'Young', NULL, NULL, NULL, NULL, 1)
) AS s ([Id], [Number], [FirstName], [LastName], [PracticeNumber], [Handedness], [PositionId], [JerseySizeId], [JerseyPaid])
	ON [t].[Id] = [s].[Id]
WHEN MATCHED THEN
	UPDATE SET
		t.[Number] = [s].[Number],
		t.[FirstName] = [s].[FirstName],
		t.[PracticeNumber] = [s].[PracticeNumber],
		t.[Handedness] = [s].[Handedness],
		t.[PositionId] = [s].[PositionId],
		t.[LastName] = [s].[LastName],
		t.[JerseySizeId] = [s].[JerseySizeId],
		t.[JerseyPaid] = [s].[JerseyPaid]
WHEN NOT MATCHED BY TARGET THEN
	INSERT ([Id], [Number], [FirstName], [LastName], [PracticeNumber], [Handedness], [PositionId], [JerseySizeId], [JerseyPaid])
	VALUES ([s].[Id], [s].[Number], [s].[FirstName], [s].[LastName], [s].[PracticeNumber], [s].[Handedness], [s].[PositionId], [s].[JerseySizeId], [s].[JerseyPaid])
WHEN NOT MATCHED BY SOURCE THEN
	DELETE;

SET IDENTITY_INSERT  [roster].[Player] OFF