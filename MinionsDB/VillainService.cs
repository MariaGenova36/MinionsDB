using System;
using System.Data.SqlClient;

public class VillainService
{
    private readonly string connectionString = "Server=localhost;Database=MinionsDB2;Integrated Security=true;";

    public void PrintVillainsWithMoreThan3Minions()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = @"
                SELECT v.Name AS VillainName, COUNT(mv.MinionId) AS MinionCount
                FROM Villains AS v
                JOIN MinionsVillains AS mv ON v.Id = mv.VillainId
                GROUP BY v.Name
                HAVING COUNT(mv.MinionId) > 3
                ORDER BY MinionCount DESC;";

            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (!reader.HasRows)
                {
                    Console.WriteLine("Няма злодеи с повече от 3 миниона");
                    return;
                }

                while (reader.Read())
                {
                    string villainName = reader["VillainName"].ToString();
                    int minionCount = (int)reader["MinionCount"];

                    Console.WriteLine($"{villainName} – {minionCount}");
                }
            }
        }
    }
}
