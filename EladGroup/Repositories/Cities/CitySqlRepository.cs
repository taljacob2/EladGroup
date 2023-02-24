using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using EladGroup.Models;

namespace EladGroup.Repositories.Cities
{
    internal class CitySqlRepository : SharedSqlRepository<City>,
        ICityRepository
    {
        protected override City FillEntry(SqlDataReader reader)
        {
            City city = new City();

            int.TryParse(reader["Id"].ToString(), out int id);
            city.Id = id;

            city.Name = reader["Name"].ToString();

            int.TryParse(reader["Priority"].ToString(), out
                int priority);
            city.Priority = priority;

            return city;
        }

        /// <summary>
        ///     Inserts a new <see cref="City" /> entity to the database.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="priority"></param>
        public void Insert(string name, int priority)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("INSERT INTO City (Name, Priority) VALUES ");
            stringBuilder.Append($"(N'{name}', {priority})");

            string query = stringBuilder.ToString();
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
    }
}
