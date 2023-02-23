using EladGroup.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EladGroup.Logics
{
    internal class CityLogic
    {
        private Startup Startup { get; } = Startup.Instance;

        public void Insert(string name, int priority)
        {
            // Create a new SQL query using StringBuilder
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("INSERT INTO City (Name, Priority) VALUES ");
            stringBuilder.Append($"(N'{name}', {priority})");

            string query = stringBuilder.ToString();
            try
            {
                using (SqlCommand sqlCommand =
                    new SqlCommand(query, Startup.SqlConnection))
                {
                    sqlCommand.ExecuteNonQuery(); // Execute the query.
                    // Console.WriteLine("Query Executed.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public List<City> Get()
        {
            return null;
        }
    }
}