using EladGroup.Misc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EladGroup.Misc._PowerShell;

namespace EladGroup
{
    internal class Startup
    {
        public ConnectionInitiator ConnectionInitiator { get; } =
            ConnectionInitiator.Instance;

        private SqlConnection SqlConnection { get; } = null;

        private PowerShellExecutor PowerShellExecutor { get; } =
            new PowerShellExecutor();

        public Startup()
        {
            // Initialize `SqlConnection`.
            string wholeConnectionString =
                ConnectionInitiator.GetConnectionStringByName
                    ("EladGroupEntities");

            string dataSourceConnectionString = wholeConnectionString.Substring
            (wholeConnectionString.IndexOf("data source",
                StringComparison.Ordinal));

            // Remote the quote mark after the string.
            dataSourceConnectionString =
                dataSourceConnectionString.Remove(
                    dataSourceConnectionString.Length - 1);

            SqlConnection = new SqlConnection(dataSourceConnectionString);
        }

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

        /// <summary>
        /// Make sure you have <a href="https://docs.microsoft.com/en-us/sql/tools/sqlcmd-utility?view=sql-server-ver15">sqlcmd</a> installed, to allow queries to the database through the cli.
        /// 
        /// It may be already installed on your computer.
        /// You can check this by running:
        /// <code>
        /// sqlcmd -?
        /// </code>
        /// </summary>
        public void InitDatabase()
        {
            PowerShellExecutor.Run("InitDatabase.ps1");
        }
    }
}