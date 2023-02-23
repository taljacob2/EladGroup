using EladGroup.Misc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EladGroup
{
    internal class Startup
    {
        public ConnectionInitiator ConnectionInitiator { get; } =
            ConnectionInitiator.Instance;

        private SqlConnection SqlConnection { get; } = new SqlConnection(
            @"data source=DESKTOP-JJHPQ0B\SQLEXPRESS;initial catalog=EladGroup;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework");

        public void OpenConnection()
        {
            try
            {
                Console.WriteLine("Opening Connection ...");
        
                // Open connection.
                SqlConnection.Open();
        
                Console.WriteLine("Connection successful!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
    }
}