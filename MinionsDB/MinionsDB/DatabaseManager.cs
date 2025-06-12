using System;
using System.Data.SqlClient;

public class DatabaseManager
{
    private readonly string connectionStringMaster = "Server=localhost;Database=master;Integrated Security=true;";
    private readonly string connectionStringMinionsDB = "Server=localhost;Database=MinionsDB2;Integrated Security=true;";

    public void CreateDatabase()
    {
        using (SqlConnection connection = new SqlConnection(connectionStringMaster))
        {
            connection.Open();
            string query = "IF DB_ID('MinionsDB2') IS NULL CREATE DATABASE MinionsDB2";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.ExecuteNonQuery();
                Console.WriteLine("MinionsDB създадена успешно.");
            }
        }
    }

    public void CreateTables()
    {
        using (SqlConnection connection = new SqlConnection(connectionStringMinionsDB))
        {
            connection.Open();

            string[] tableQueries = new string[]
            {
                "CREATE TABLE Countries (Id INT PRIMARY KEY IDENTITY, Name NVARCHAR(50))",
                "CREATE TABLE Towns (Id INT PRIMARY KEY IDENTITY, Name NVARCHAR(50), CountryCode INT FOREIGN KEY REFERENCES Countries(Id))",
                "CREATE TABLE Minions (Id INT PRIMARY KEY IDENTITY, Name NVARCHAR(50), Age INT, TownId INT FOREIGN KEY REFERENCES Towns(Id))",
                "CREATE TABLE EvilnessFactors (Id INT PRIMARY KEY IDENTITY, Name NVARCHAR(50))",
                "CREATE TABLE Villains (Id INT PRIMARY KEY IDENTITY, Name NVARCHAR(50), EvilnessFactorId INT FOREIGN KEY REFERENCES EvilnessFactors(Id))",
                "CREATE TABLE MinionsVillains (MinionId INT FOREIGN KEY REFERENCES Minions(Id), VillainId INT FOREIGN KEY REFERENCES Villains(Id), PRIMARY KEY (MinionId, VillainId))"
            };

            foreach (var query in tableQueries)
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.ExecuteNonQuery();
                }
            }

            Console.WriteLine("Таблиците са създадени успешно.");
        }
    }

    public void SeedBasicData()
    {
        using (SqlConnection connection = new SqlConnection(connectionStringMinionsDB))
        {
            connection.Open();

            string[] inserts = new string[]
            {
                // Countries
                "INSERT INTO Countries (Name) VALUES ('Bulgaria'), ('USA'), ('Germany')",

                // Towns
                "INSERT INTO Towns (Name, CountryCode) VALUES ('Sofia', 1), ('Plovdiv', 1), ('New York', 2)",

                // Evilness Factors
                "INSERT INTO EvilnessFactors (Name) VALUES ('Super good'), ('Good'), ('Bad'), ('Evil'), ('Super evil')"
            };

            foreach (var query in inserts)
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.ExecuteNonQuery();
                }
            }

            Console.WriteLine("Базовите данни са въведени.");
        }
    }
}
