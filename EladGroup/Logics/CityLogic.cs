﻿using System;
using System.Collections.Generic;
using EladGroup.Models;
using EladGroup.Repositories.Cities;

namespace EladGroup.Logics
{
    internal class CityLogic
    {
        private const int CityNameMaxCharCount = 50;

        private ICityRepository CityRepository { get; } =
            new CitySqlRepository();

        /// <summary>
        ///     Inserts a new <see cref="City" /> entity to the database.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="priority"></param>
        /// <exception cref="Exception">In case `City.Name`'s length is too long.</exception>
        /// <see cref="CityNameMaxCharCount" />
        public void Insert(string name, int priority)
        {
            if (name.Length > CityNameMaxCharCount)
            {
                throw new Exception("`City.Name`'s length is too long");
            }

            Console.WriteLine("Inserting to db...");
            CityRepository.Insert(name, priority);
        }

        public List<City> Get()
        {
            return CityRepository.Get();
        }

        public List<City> GetOrderByPriority()
        {
            return CityRepository.GetOrderByPriority();
        }
    }
}
