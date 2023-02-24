using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using EladGroup.Models;
using EladGroup.Models.Customs;
using EladGroup.Models.Customs.Joins;
using EladGroup.Repositories.Shared;

namespace EladGroup.Repositories.Streets
{
    internal class StreetSqlRepository : SharedSqlRepository, IStreetRepository

    {
        /// <summary>
        ///     Inserts a new <see cref="Street" /> entity to the database.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="priority"></param>
        /// <param name="cityId"></param>
        public void Insert(string name, int priority, int cityId)
        {
            string query = $@"
INSERT INTO Street (Name, Priority, CityId) VALUES
(N'{name}', {priority}, {cityId}) 
";

            RunVoidQuery(query);
        }

        public List<Street> Get()
        {
            return RunListQuery<Street>("SELECT * FROM Street");
        }

        public List<Street> GetOrderByPriority()
        {
            return RunListQuery<Street>(
                "SELECT * FROM Street ORDER BY Priority");
        }

        public List<Street> GetByCityOrderByPriority()
        {
            string query = @"
SELECT	
		Street.Id AS StreetId,
		Street.Name AS StreetName,
		Street.Priority AS StreetPriority,
		Street.CityId,
		City.Name AS CityName,
		City.Priority AS CityPriority
FROM Street
JOIN City ON Street.CityId = City.Id
ORDER BY Street.Priority
";

            List<StreetJoinCity> streetJoinCityList =
                RunListQuery<StreetJoinCity>(query);

            List<Street> returnValue = new List<Street>();

            streetJoinCityList.ForEach(streetJoinCity =>
            {
                Street street = new Street();

                street.Id = streetJoinCity.StreetId;
                street.Name = streetJoinCity.StreetName;
                street.Priority = streetJoinCity.StreetPriority;
                street.CityId = streetJoinCity.CityId;

                returnValue.Add(street);
            });

            return returnValue;
        }
    }
}
