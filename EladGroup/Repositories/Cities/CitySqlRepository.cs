using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using EladGroup.Models;
using EladGroup.Repositories.Shared;

namespace EladGroup.Repositories.Cities
{
    internal class CitySqlRepository : SharedSqlRepository<City>,
        ICityRepository
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
            return RunListQuery("SELECT * FROM City");
        }

        public List<City> GetOrderByPriority()
        {
            return RunListQuery("SELECT * FROM City ORDER BY Priority");
        }

        // protected override City FillEntry(SqlDataReader reader)
        // {
        //     City city = new City();
        //
        //     int.TryParse(reader["Id"].ToString(), out int id);
        //     city.Id = id;
        //
        //     city.Name = reader["Name"].ToString();
        //
        //     int.TryParse(reader["Priority"].ToString(), out
        //         int priority);
        //     city.Priority = priority;
        //
        //     return city;
        // }
    }
}
