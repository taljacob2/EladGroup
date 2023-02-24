using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using EladGroup.Models;
using EladGroup.Repositories.Shared;

namespace EladGroup.Repositories.Streets
{
    internal class StreetSqlRepository : SharedSqlRepository<Street>,
        IStreetRepository

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
            return RunListQuery("SELECT * FROM Street");
        }

        public List<Street> GetOrderByPriority()
        {
            return RunListQuery("SELECT * FROM Street ORDER BY Priority");
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

            return RunListQuery(query);
            throw new NotImplementedException();
        }
    }
}
