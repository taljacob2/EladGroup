using EladGroup.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EladGroup.Logics
{
    internal class CityLogic : SharedLogic<City>
    {
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

        protected override City FillEntry(SqlDataReader reader)
        {
            City city = new City();

            Int32.TryParse(reader["Id"].ToString(), out int id);
            city.Id = id;

            city.Name = reader["Name"].ToString();

            Int32.TryParse(reader["Priority"].ToString(), out
                int priority);
            city.Priority = priority;

            return city;
        }
    }
}