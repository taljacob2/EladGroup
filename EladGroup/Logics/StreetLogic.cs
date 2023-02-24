using System;
using System.Collections.Generic;
using EladGroup.Models;
using EladGroup.Repositories.Streets;

namespace EladGroup.Logics
{
    internal class StreetLogic
    {
        private const int StreetNameMaxCharCount = 50;

        private IStreetRepository StreetRepository { get; } =
            new StreetSqlRepository();

        /// <summary>
        ///     Inserts a new <see cref="Street" /> entity to the database.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="priority"></param>
        /// <param name="cityId"></param>
        /// <exception cref="Exception">In case `Street.Name`'s length is too long.</exception>
        /// <exception cref="Exception">In case `Street.CityId` points to a non-existing `City.Id`.</exception>
        /// <see cref="StreetNameMaxCharCount" />
        public void Insert(string name, int priority, int cityId)
        {
            if (name.Length > StreetNameMaxCharCount)
            {
                throw new Exception("`Street.Name`'s length is too long");
            }

            // TODO: Check if `cityId` is an existing cityId.

            StreetRepository.Insert(name, priority, cityId);
        }

        public List<Street> Get()
        {
            return StreetRepository.Get();
        }

        public List<Street> GetOrderByPriority()
        {
            return StreetRepository.GetOrderByPriority();
        }
    }
}
