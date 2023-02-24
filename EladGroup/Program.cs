using System;
using EladGroup.Consoles;

namespace EladGroup
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World");

            // Startup startup = Startup.Instance;
            
            // TODO: Check ps1 script path.
            // startup.InitDatabase();

            CityConsole cityConsole = new CityConsole();
            StreetConsole streetConsole = new StreetConsole();

            // CityLogic cityLogic = new CityLogic();
            // cityLogic.Insert("Eilat", 1);
            // streetLogic.Insert("Ben Gurion", 3, 5);

            // cityConsole.GetOrderByPriority();
            // streetConsole.Get();

            // try
            // {
            //     // cityConsole.Insert();
            //     streetConsole.Insert();
            // }
            // catch (Exception e)
            // {
            //     Console.WriteLine(e);
            // }
            
            new MainConsole().Run();
        }
    }
}
