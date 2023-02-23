using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EladGroup.Models;

namespace EladGroup.Logics
{
    internal class StreetLogic : SharedLogic<Street>
    {
        public void Insert(string name, int priority, int cityId)
        {
            // Create a new SQL query using StringBuilder
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

        protected override Street FillEntry(SqlDataReader reader)
        {
            Street street = new Street();

            Int32.TryParse(reader["Id"].ToString(), out int id);
            street.Id = id;

            street.Name = reader["Name"].ToString();

            Int32.TryParse(reader["Priority"].ToString(), out
                int priority);
            street.Priority = priority;

            Int32.TryParse(reader["CityId"].ToString(), out
                int cityId);
            street.CityId = cityId;

            return street;
        }
    }
}