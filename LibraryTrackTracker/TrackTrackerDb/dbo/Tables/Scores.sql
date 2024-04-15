CREATE TABLE [dbo].[Scores]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Value] DECIMAL NOT NULL,
	[Stat] NVARCHAR(50) NOT NULL,
	[UserId] INT NOT NULL,
	[TrackId] INT NOT NULL,
	FOREIGN KEY ([TrackId]) REFERENCES [dbo].[Tracks]([Id]),
	FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users]([Id]),
)
