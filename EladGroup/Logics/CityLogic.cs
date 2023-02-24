using System;
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

        public City FindCityWithHighestId(List<City> cityList)
        {
            if (cityList == null)
            {
                return null;
            }

            if (cityList.Count == 0)
            {
                return null;
            }

            City returnValue = cityList[0];

            foreach (City city in cityList)
            {
                if (city.Id > returnValue.Id)
                {
                    returnValue = city;
                }
            }

            return returnValue;
        }
    }
}
