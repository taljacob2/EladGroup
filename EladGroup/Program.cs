using EladGroup.Misc;
using System;
using EladGroup._Console;
using EladGroup.Logics;

namespace EladGroup
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World");

            // Startup startup = Startup.Instance;
            // startup.InitDatabase();
            
            CityConsole cityConsole = new CityConsole();
            StreetConsole streetConsole = new StreetConsole();
            
            CityLogic cityLogic = new CityLogic();
            cityLogic.Insert("Haifa", 7);
            // streetLogic.Insert("Ben Gurion", 3, 5);

            cityConsole.Get();
            // streetConsole.Get();
        }
    }
}