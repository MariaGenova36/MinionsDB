using System.Data.SqlClient;
using System;

public class DatabaseSeeder
{
    private readonly string connectionString = "Server=localhost;Database=MinionsDB2;Integrated Security=true;";

    public void SeedData()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            var commands = new[]
            {
                // Злодеи
                "INSERT INTO Villains (Name, EvilnessFactorId) VALUES ('Gru', 5)",
                "INSERT INTO Villains (Name, EvilnessFactorId) VALUES ('Victor', 4)",
                "INSERT INTO Villains (Name, EvilnessFactorId) VALUES ('Jilly', 3)",

                // Миниони
                "INSERT INTO Minions (Name, Age, TownId) VALUES ('Tom', 10, 1)",
                "INSERT INTO Minions (Name, Age, TownId) VALUES ('Jerry', 12, 1)",
                "INSERT INTO Minions (Name, Age, TownId) VALUES ('Mark', 11, 2)",
                "INSERT INTO Minions (Name, Age, TownId) VALUES ('Bob', 9, 2)",
                "INSERT INTO Minions (Name, Age, TownId) VALUES ('Ned', 13, 3)",
                "INSERT INTO Minions (Name, Age, TownId) VALUES ('Jim', 8, 3)",

                // Връзки
                "INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (1,1),(2,1),(3,1),(4,1),(5,1),(6,1)",
                "INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (1,2),(2,2),(3,2),(4,2)",
                "INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (3,3),(4,3),(5,3),(6,3)"
            };

            foreach (var cmdText in commands)
            {
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.ExecuteNonQuery();
                }
            }

            Console.WriteLine("Данните са заредени.");
        }
    }
}
