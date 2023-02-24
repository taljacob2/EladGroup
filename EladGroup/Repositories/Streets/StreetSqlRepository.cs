using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using EladGroup.Models;
using EladGroup.Repositories.Shared;

namespace EladGroup.Repositories.Streets
{
    internal class StreetSqlRepository : SharedSqlRepository<Street>,
        IStreetRepository

    {
        protected override Street FillEntry(SqlDataReader reader)
        {
            Street street = new Street();

            int.TryParse(reader["Id"].ToString(), out int id);
            street.Id = id;

            street.Name = reader["Name"].ToString();

            int.TryParse(reader["Priority"].ToString(), out
                int priority);
            street.Priority = priority;

            int.TryParse(reader["CityId"].ToString(), out
                int cityId);
            street.CityId = cityId;

            return street;
        }
        
        /// <summary>
        ///     Inserts a new <see cref="Street" /> entity to the database.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="priority"></param>
        /// <param name="cityId"></param>
        public void Insert(string name, int priority, int cityId)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(
                "INSERT INTO Street (Name, Priority, CityId) VALUES ");
            stringBuilder.Append($"(N'{name}', {priority}, {cityId})");

            string query = stringBuilder.ToString();
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
            throw new System.NotImplementedException();
        }
    }
}
