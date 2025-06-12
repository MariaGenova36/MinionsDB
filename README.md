MinionsDB

A simple C# console application that connects to a SQL database to manage minions and villains.

Overview

This project was created as an educational example for database interaction using C# and SQL. It demonstrates:

- Creating and connecting to a SQL database
- Executing SQL commands from C#
- Managing data (CRUD operations)
- Relating entities (e.g. assigning minions to villains)

Technologies Used

- C#
- .NET Framework
- SQL Server
- ADO.NET
- Console Application

Features

- Add new minions and villains
- Assign minions to villains
- View minions by villain
- Seed initial data in the database


Structure

- `DatabaseManager.cs`: Handles all DB connections
- `MinionService.cs`: Logic for managing minions
- `VillainService.cs`: Logic for managing villains
- `DatabaseSeeder.cs`: Seeds initial data into the DB
- `Program.cs`: Entry point of the application


