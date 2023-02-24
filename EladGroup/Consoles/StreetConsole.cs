using System;
using EladGroup.Logics;
using EladGroup.Misc.Extensions;
using EladGroup.Models;

namespace EladGroup.Consoles
{
    internal class StreetConsole
    {
        private StreetLogic StreetLogic { get; } = new StreetLogic();

        /// <summary>
        ///     Inserts a new <see cref="Street" /> entity to the database, by
        ///     receiving inputs from the user via a console interface.
        /// </summary>
        /// <exception cref="Exception">In case failed to parse `Street.Priority`</exception>
        /// <exception cref="Exception">In case `Street.Name`'s length is too long.</exception>
        public void Insert()
        {
            string input = null;

            Console.Write("Street.Name: ");
            input = Console.ReadLine();
            string name = input;

            Console.Write("Street.Priority: ");
            input = Console.ReadLine();
            if (!int.TryParse(input, out int priority))
            {
                throw new Exception("Failed to parse `Street.Priority`");
            }

            Console.Write("Street.CityId: ");
            input = Console.ReadLine();
            if (!int.TryParse(input, out int cityId))
            {
                throw new Exception("Failed to parse `Street.CityId`");
            }

            Console.WriteLine("Inserting to db...");
            StreetLogic.Insert(name, priority, cityId);
        }

        public void Get()
        {
            StreetLogic.Get().ForEach(street =>
                Console.WriteLine(street.ToStringExtension()));
        }

        public void GetOrderByPriority()
        {
            StreetLogic.GetOrderByPriority().ForEach(street =>
                Console.WriteLine(street.ToStringExtension()));
        }
    }
}
