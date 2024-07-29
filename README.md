<h1>Track Tracker</h1>
Track Tracker is a full-stack web application that allows users to engage in a social platform where they can share music tracks (both original and from established artists) to get feedback from other users. This feedback, represented in numerical values based on seven different criteria, is displayed as data so it can be arranged and perceived from various perspectives for comparison and further comprehension. 

The app is currently in beta testing and available in my GitHub page.

<h1>Project Structure</h1>

<h2>LibraryTrackTracker (.dll)</h2>

<h3>Db</h3>
<p>
    This folder contains C# classes for accessing the database. Currently, it is implemented with a SQL Server database. However, it is designed to be easily adaptable to other DBMS through dependency injection.
</p>

<h3>Models</h3>
<p>
    Contains model classes, including an interface that serves as an abstraction for business logic purposes.
</p>

<h3>Data</h3>
<p>
    Contains data access classes for each model, along with their respective interfaces to support dependency injection.
</p>

<h2>TrackTrackerDb</h2>
Tables and Stored Procedures. 

<h2>ASPTrackTracker</h2>

<h3>Auth</h3>



