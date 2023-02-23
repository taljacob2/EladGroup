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
            // Create a new SQL query using StringBuilder
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("INSERT INTO City (Name, Priority) VALUES ");
            stringBuilder.Append($"(N'{name}', {priority})");

            string query = stringBuilder.ToString();
            RunVoidQuery(query);
        }

        public List<City> Get()
        {
            List<City> returnValue = new List<City>();

            using (SqlConnection sqlConnection =
                new SqlConnection(Startup.ConnectionInitiator.ConnectionString))
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
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            return returnValue;
        }
        
        public List<City> GetOrderByPriority()
        {
            List<City> returnValue = new List<City>();

            using (SqlConnection sqlConnection =
                new SqlConnection(Startup.ConnectionInitiator.ConnectionString))
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
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            return returnValue;
        }
    }
}