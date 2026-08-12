# Track Tracker

Track Tracker is a .NET 8 Razor Pages application for publishing music tracks, rating them across multiple criteria, and exploring aggregated feedback and statistics.

The project was built as a full-stack learning project with a separate data-access library and a SQL Server database project included in the repository.

## Main features

- User registration, login, and cookie-based authentication.
- Track publishing with artist, genre, style, and external listening links.
- Multi-criteria track ratings.
- Track, artist, and user statistics.
- Filtering and sorting across published content.
- SQL Server persistence through Dapper and stored procedures.

## Technology

- C# / .NET 8
- ASP.NET Core Razor Pages
- SQL Server
- Dapper
- BCrypt.Net
- HTML / CSS

## Architecture

The repository is split into three main parts:

- `ASPTrackTrackerS/ASPTrackTracker/` — web application and Razor Pages UI.
- `LibraryTrackTracker/LibraryTrackTracker/` — models and data-access layer.
- `LibraryTrackTracker/TrackTrackerDb/` — SQL Server database project with table definitions and stored procedures.

The web application references the data-access library as a project dependency, so the repository no longer depends on a locally compiled DLL.

## Database

The database project includes definitions for:

- Users
- Tracks
- Artists
- Genres
- Styles
- Scores

Stored procedures for the application's data operations are also included in the repository.

A SQL Server connection string must be supplied through configuration. For deployment, it can be provided through the `ConnectionStrings__Default` environment variable instead of committing credentials to the repository.

## Running locally

Requirements:

- .NET 8 SDK
- SQL Server

After creating the database from `LibraryTrackTracker/TrackTrackerDb`, configure the `Default` connection string and run:

```bash
dotnet run --project ASPTrackTrackerS/ASPTrackTracker/ASPTrackTracker.csproj
```

The original production database contents are not included in the repository, so a new database starts without the historical application data.

## Project status

The source code is preserved as a portfolio project and is not currently maintained as a public live deployment.
