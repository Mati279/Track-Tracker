<h1>Track Tracker</h1>
        <p>Track Tracker is a full-stack web application designed to let users engage in a social platform where they can share and receive feedback on music tracks. Users can share both original tracks and tracks from established artists to gather feedback based on seven different criteria. This feedback is displayed as data, allowing users to arrange and analyze it from various perspectives for comparison and better understanding.</p>
        <p>The application is currently in beta testing. Upcoming features include notifications, password recovery via email, and client-side management of filters and sorting through JavaScript.</p>
        <p>Please check and participate in the beta application through this link: <a href="https://www.asptracktracker.somee.com">Track Tracker Beta</a>.</p>
            
<h1>Application Architecture Overview</h1>
    <p>The architecture of the Track Tracker application is designed to create a robust and scalable full-stack solution. The application leverages a combination of technologies including SQL Server, Dapper, C#, ASP.NET Razor, HTML, and CSS. Here's an in-depth look at how these components work together to form the architecture of the application:</p>

<h2>Database Layer: SQL Server</h2>
<p>At the core of the Track Tracker application is SQL Server, a powerful relational database management system used to store and manage the application's data. The database layer is responsible for handling all data-related operations.</p>

<h2>Data Access Layer: Dapper</h2>
<p>Dapper is a lightweight Object-Relational Mapper (ORM), it sits between the SQL Server database and the application's business logic, providing an efficient way to interact with the database.</p>

<h2>Business Logic Layer: C#</h2>
<p>The business logic layer is implemented in C# and handles the core functionality of the application, this layer includes:</p> 
<p>Models: C# classes representing the application's data entities such as tracks, artists, and user ratings. These models are used to map data between the database and the application.</p>
<p>Services: C# classes that contain the business logic for operations such as rating a track, publishing new tracks, and retrieving track statistics. These services interact with Dapper to execute database operations and process the results.</p>

<h2>Presentation Layer: ASP.NET Razor, HTML, and CSS</h2>
<p>The presentation layer is responsible for the user interface and user experience of the application. It is built using ASP.NET Razor Pages, HTML, and CSS.</p>

<h1>Application Folders Structure</h1>

<h2>Index</h2>
<p>The Index page provides an overview of the user's published tracks and the tracks they need to rate (published by others or their own).</p>
<p><strong>Work in Progress:</strong> Adding notifications to alert users when a published track is rated by others or when a new track is posted.</p>

<h2>Publish</h2>
<p>Here, users can publish a new track for others to listen to and rate. Users can specify the artist and style of the track and provide a link to the track to ensure listeners access the intended version.</p>
<p>If the artist is not in the database, a link to create a new artist is provided.</p>

<h2>Tracks</h2>
<p>The Tracks view displays all published tracks (from all users). Users can access the provided links to listen to the tracks, and a complex system of filters and sorting allows querying the database based on different criteria. The query is displayed above the table for clarity.</p>
<p>If a track has not yet been rated by the user, a button directs them to the Rate Track view. If the track has already been rated, a button to view the track's details is available.</p>

<h2>Rate Track</h2>
<p>Users can rate a track on a scale of 1 to 10 across six criteria: Affinity, Complexity, Creativity, Lyrics, Instrumental, and Voices. Some criteria may not apply to all tracks. For instance, instrumental tracks may not have scores for Voices and Lyrics.</p>

<h2>View Track</h2>
<p>The View Track page displays statistics for a given track, including basic information such as Published By, Artist, Style, etc. Users can modify their rating and view ratings from other users, as well as average scores.</p>

<h2>Artists</h2>
<p>Similar to the Tracks view, this page showcases all artists added to the database. It allows filtering and sorting by different queries. A button is provided to access the Artist View.</p>

<h2>Artist View</h2>
<p>Displays basic information about a given artist.</p>

<h1>Files Structure</h1>

<h2>LibraryTrackTracker</h2>

<h3>Db</h3>
<p>This folder contains C# classes for database access. Currently implemented with SQL Server, but designed for easy adaptation to other DBMS through dependency injection.</p>

<h3>Models</h3>
<p>Includes model classes and an interface for abstraction purposes in business logic.</p>

<h3>Data</h3>
<p>Holds data access classes for each model, along with their interfaces to support dependency injection.</p>

<h2>TrackTrackerDb</h2>
<p>Includes tables and stored procedures.</p>

<h2>ASPTrackTracker</h2>

<h3>Auth</h3>
<p>Contains the AuthenticatedPageModel class, inheriting from PageModel to provide user identification through cookies.</p>

<h3>Comparers</h3>
<p>Helper classes for personalized object comparisons.</p>

<h3>Fillers and Filters</h3>
<p>Helper classes for managing filters and populating select lists.</p>

<h3>Pages</h3>
<p>Contains .cshtml and .cshtml.cs files for every view in the application.</p>

<h3>Score Helpers</h3>
<p>Helper classes for managing track score sorting and comparison.</p>
