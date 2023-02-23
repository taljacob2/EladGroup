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
                using (SqlCommand cmd =
                    new SqlCommand(query, Startup.SqlConnection))
                {
                    cmd.ExecuteNonQuery(); // Execute the query.
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
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM whatever WHERE id = 5", conn);
                try
                {
                    conn.Open();
                    newID = (int)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}