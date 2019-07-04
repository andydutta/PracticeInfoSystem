# PracticeInformationSystem

The application is developed using VS2019 using Angular7 implemented as webAPI as MVC architecture. The data access is through EntityFramework.Core. The database is self contained in the SQLite database and all the tables are generated with required data. The MedPractice.db should be copied into C:\Sqlite folder before running the application.

Assumputions:

1. The dependency for the assemblies can be acquired through the Nuget package manager and while running the application internet access will be available
2. Data used for testing has been already been added based on the information provided in the specification document and used as is.
3. There are no specification for the landing page hence the list of doctor view is treated as the landing page
4. Setup for the menu and navigation has not been discussed in the specification and so the default behavior is implemented

Suggestion:

1. The work flow of the project can be more streamlined with the description of the landing page with the navigation menus options specified as needed.
2. The detail view and the list view of doctor mostly show similar information. So it is not clear as on what basis details information page is being displayed for a doctor.
