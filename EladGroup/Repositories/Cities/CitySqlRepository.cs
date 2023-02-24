using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using EladGroup.Models;
using EladGroup.Repositories.Shared;

namespace EladGroup.Repositories.Cities
{
    internal class CitySqlRepository : SharedSqlRepository, ICityRepository
    {
        /// <summary>
        ///     Inserts a new <see cref="City" /> entity to the database.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="priority"></param>
        public void Insert(string name, int priority)
        {
            string query = $@"
INSERT INTO City (Name, Priority) VALUES 
(N'{name}', {priority})
";
            RunVoidQuery(query);
        }

        public List<City> Get()
        {
            return RunListQuery<City>("SELECT * FROM City");
        }

        public List<City> GetOrderByPriority()
        {
            return RunListQuery<City>("SELECT * FROM City ORDER BY Priority");
        }
    }
}
