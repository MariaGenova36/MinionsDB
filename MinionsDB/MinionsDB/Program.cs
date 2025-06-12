using System;

class Program
{
    static void Main()
    {
        ///var dbManager = new DatabaseManager();
        // dbManager.CreateDatabase();
        //dbManager.CreateTables();
        //dbManager.SeedBasicData();

        //  var seeder = new DatabaseSeeder();
        // seeder.SeedData();

        var villainService = new VillainService();
        villainService.PrintVillainsWithMoreThan3Minions();

        Console.WriteLine("Готово.");
        //Minion names
        Console.Write("Въведи ID на злодей: ");
        int villainId = int.Parse(Console.ReadLine());

      //  var minionService = new MinionService();
       // minionService.PrintMinionsByVillainId(villainId);
    }
}
