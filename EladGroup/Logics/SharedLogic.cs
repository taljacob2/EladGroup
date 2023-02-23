using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace EladGroup.Logics
{
    internal class SharedLogic<T> where T : class, new()
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

        private T FillEntry(SqlDataReader reader)
        {
            T t = new T();

            Int32.TryParse(reader["Id"].ToString(), out int id);
            t.Id = id;

            t.Name = reader["Name"].ToString();

            Int32.TryParse(reader["Priority"].ToString(), out
                int priority);
            city.Priority = priority;

            return t;
        }

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