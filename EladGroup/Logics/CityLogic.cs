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
            List<City> returnValue = new List<City>();

            using (SqlConnection sqlConnection = Startup.SqlConnection)
            {
                SqlCommand cmd =
                    new SqlCommand("SELECT * FROM City", sqlConnection);
                try
                {
                    sqlConnection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            City city = new City();

                            Int32.TryParse(reader["Id"].ToString(), out int id);
                            city.Id = id;

                            city.Name = reader["Name"].ToString();

                            Int32.TryParse(reader["Priority"].ToString(), out
                                int priority);
                            city.Priority = priority;

                            returnValue.Add(city);
                        }

                        sqlConnection.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return returnValue;
        }
    }
}