using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EladGroup.Models;

namespace EladGroup.Logics
{
    internal class StreetLogic
    {
        private Startup Startup { get; } = Startup.Instance;

        public void Insert(string name, int priority, int cityId)
        {
            // Create a new SQL query using StringBuilder
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(
                "INSERT INTO Street (Name, Priority, CityId) VALUES ");
            stringBuilder.Append($"(N'{name}', {priority}, {cityId})");

            string query = stringBuilder.ToString();
            try
            {
                using (SqlCommand cmd =
                    new SqlCommand(query,
                        new SqlConnection(Startup.ConnectionInitiator
                            .ConnectionString)))
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

        public List<Street> Get()
        {
            List<Street> returnValue = new List<Street>();

            using (SqlConnection sqlConnection =
                new SqlConnection(Startup.ConnectionInitiator.ConnectionString))
            {
                SqlCommand cmd =
                    new SqlCommand("SELECT * FROM Street", sqlConnection);
                try
                {
                    sqlConnection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
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

                            returnValue.Add(street);
                        }

                        sqlConnection.Close();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            return returnValue;
        }
    }
}