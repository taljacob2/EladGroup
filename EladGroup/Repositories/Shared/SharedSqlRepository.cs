using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;
using EladGroup.Misc.Extensions;
using EladGroup.Models;

namespace EladGroup.Repositories.Shared
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

        protected static T FillEntry(SqlDataReader reader)
        {
            T returnValue = new T();

            PropertyInfo[] propertyArray =
                returnValue.GetType().GetProperties();

            foreach (PropertyInfo property in propertyArray)
            {
                if (property.PropertyType == typeof(int))
                {
                    int.TryParse(reader[property.Name].ToString(),
                        out int propertyAsInt);
                    returnValue.SetProperty(property, propertyAsInt);
                }
                else if (property.PropertyType == typeof(string))
                {
                    returnValue.SetProperty(property,
                        reader[property.Name].ToString());
                }
            }

            return returnValue;
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
