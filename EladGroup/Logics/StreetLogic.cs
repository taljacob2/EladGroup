using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}