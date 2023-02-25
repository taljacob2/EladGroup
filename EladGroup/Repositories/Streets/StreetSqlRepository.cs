using System.Collections.Generic;
using EladGroup.Models;
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

        public List<Street> GetByCityOrderByPriority(int cityId)
        {
            string query = $@"
SELECT *
FROM Street
WHERE Street.CityId = {cityId}
ORDER BY Street.Priority
";

            return RunListQuery<Street>(query);;
        }
    }
}
