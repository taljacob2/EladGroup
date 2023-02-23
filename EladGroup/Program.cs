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
            
            // cityLogic.Insert("Ramat Gan", 5);
            // streetLogic.Insert("Ben Gurion", 3, 5);

            cityConsole.Get();
        }
    }
}