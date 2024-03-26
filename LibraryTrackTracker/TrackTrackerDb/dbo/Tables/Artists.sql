CREATE TABLE [dbo].[Artists]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(50) NOT NULL,
    [GenreId] INT NOT NULL,
    FOREIGN KEY ([GenreId]) REFERENCES [dbo].[Genres]([Id])
);
