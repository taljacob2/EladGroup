using EladGroup.Misc;
using System;
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
            
            CityLogic cityLogic = new CityLogic();
            StreetLogic streetLogic = new StreetLogic();
            
            // cityLogic.Insert("Ramat Gan", 5);
            streetLogic.Insert("Ben Gurion", 3, 5);
            
        }
    }
}