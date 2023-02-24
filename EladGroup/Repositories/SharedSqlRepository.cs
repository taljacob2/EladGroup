using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace EladGroup.Repositories
{
    internal abstract class SharedSqlRepository<T> where T : class, new()
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
                    using (SqlCommand cmd = new SqlCommand(query, sqlConnection)
                    )
                    {
                        sqlConnection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        protected abstract T FillEntry(SqlDataReader reader);

        protected List<T> RunListQuery(string query)
        {
            List<T> returnValue = new List<T>();

            using (SqlConnection sqlConnection =
                new SqlConnection(Startup.ConnectionInitiator.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                try
                {
                    sqlConnection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            returnValue.Add(FillEntry(reader));
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