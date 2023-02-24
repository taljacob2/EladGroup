using System;
using EladGroup.Logics;
using EladGroup.Misc;
using EladGroup.Models;

namespace EladGroup.Consoles
{
    internal class CityConsole
    {
        private CityLogic CityLogic { get; } = new CityLogic();

        /// <summary>
        ///     Inserts a new <see cref="City" /> entity to the database, by
        ///     receiving inputs from the user via a console interface.
        /// </summary>
        /// <exception cref="Exception">In case failed to parse `City.Priority`</exception>
        /// <exception cref="Exception">In case `City.Name`'s length is too long.</exception>
        public void Insert()
        {
            string input = null;

            Console.Write("City.Name: ");
            input = Console.ReadLine();
            string name = input;

            Console.Write("City.Priority: ");
            input = Console.ReadLine();
            if (!int.TryParse(input, out int priority))
            {
                throw new Exception("Failed to parse `City.Priority`");
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
