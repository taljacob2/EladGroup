using System;
using System.Collections.Generic;
using EladGroup.Logics;
using EladGroup.Misc.Extensions;
using EladGroup.Models;

namespace EladGroup.Consoles
{
    internal class StreetConsole
    {
        private StreetLogic StreetLogic { get; } = new StreetLogic();

        private CityLogic CityLogic { get; } = new CityLogic();

        /// <summary>
        ///     Gets the `Street.CityId` property by receiving inputs from the user via a
        ///     console interface.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception">In case failed to parse `Street.CityId`</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     In case `Street.CityId` is out of range
        /// </exception>
        private int GetCityId()
        {
            Console.WriteLine(
                "---------------- Pick a `City.Id` from the following options: ----------------");

            List<City> cityList = CityLogic.Get();
            cityList.ForEach(city =>
                Console.WriteLine(
                    $"City.Id: {city.Id} | City.Name: {city.Name}"));

            string input = Console.ReadLine();
            if (!int.TryParse(input, out int cityId))
            {
                throw new Exception("Failed to parse `Street.CityId`");
            }

            if (cityId > CityLogic.FindCityWithHighestId(cityList).Id ||
                cityId < 1)
            {
                throw new ArgumentOutOfRangeException("Street.CityId",
                    "`Street.CityId` is out of range");
            }

            return cityId;
        }

        /// <summary>
        ///     Inserts a new <see cref="Street" /> entity to the database, by
        ///     receiving inputs from the user via a console interface.
        /// </summary>
        /// <exception cref="Exception">In case failed to parse `Street.Priority`</exception>
        /// <exception cref="Exception">In case `Street.Name`'s length is too long.</exception>
        /// <exception cref="Exception">In case failed to parse `Street.CityId`</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     In case `Street.CityId` is out of range
        /// </exception>
        /// <see cref="GetCityId"/>
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
            int cityId = GetCityId();

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
