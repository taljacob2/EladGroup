using System;
using EladGroup.Logics;
using EladGroup.Misc;

namespace EladGroup._Console
{
    internal class CityConsole
    {
        private CityLogic CityLogic { get; } = new CityLogic();

        public void Insert()
        {
            string input = null;

            Console.Write("City.Name: ");
            input = Console.ReadLine();
            string name = input;

            Console.Write("City.Priority: ");
            input = Console.ReadLine();
            if (!Int32.TryParse(input, out int priority))
            {
                Console.Error.WriteLine("Failed to parse `City.Priority`");
                return;
            }

            Console.WriteLine("Inserting to db...");
            CityLogic.Insert(name, priority);
        }

        public void Get()
        {
            CityLogic.Get().ForEach(city =>
                Console.WriteLine(city.ToStringExtension()));
        }

        public void GetOrderByPriority()
        {
            CityLogic.GetOrderByPriority().ForEach(city =>
                Console.WriteLine(city.ToStringExtension()));
        }
    }
}