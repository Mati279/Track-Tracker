CREATE TABLE [dbo].[Tracks]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(220) NOT NULL,
	[Link] NVARCHAR(220),
	[UserId] INT NOT NULL, 
	[ArtistId] INT NOT NULL, 
	[GenreId] INT NULL, 
	[StyleId] INT NULL, 

	FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users]([Id]),
	FOREIGN KEY ([ArtistId]) REFERENCES [dbo].[Artists]([Id]) ON DELETE CASCADE,
	FOREIGN KEY ([GenreId]) REFERENCES [dbo].[Genres]([Id]),
	FOREIGN KEY ([StyleId]) REFERENCES [dbo].[Styles]([Id])
);
