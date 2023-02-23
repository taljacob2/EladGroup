using EladGroup.Misc;
using System;

namespace EladGroup
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World");

            Startup startup = new Startup();
            
            // startup.InitDatabase();
            
            startup.OpenConnection();
        }
    }
}