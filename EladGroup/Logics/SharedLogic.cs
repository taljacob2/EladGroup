using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace EladGroup.Logics
{
    internal class SharedLogic<T> where T : class
    {
        protected Startup Startup { get; } = Startup.Instance;

        protected void RunVoidQuery(string query)
        {
            try
            {
                using (SqlConnection sqlConnection =
                    new SqlConnection(Startup.ConnectionInitiator
                        .ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                    {
                        sqlConnection.Open();
                        cmd.ExecuteNonQuery(); // Execute the query.
                        // Console.WriteLine("Query Executed.");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}