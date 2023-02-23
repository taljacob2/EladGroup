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
    
    /// <summary>
    /// Singleton implementation.
    /// 
    /// References:
    /// https://www.c-sharpcorner.com/UploadFile/8911c4/singleton-design-pattern-in-C-Sharp/
    /// </summary>
    internal sealed class Startup
    {
        private ConnectionInitiator ConnectionInitiator { get; } =
            ConnectionInitiator.Instance;

        public SqlConnection SqlConnection { get; } = null;

        private PowerShellExecutor PowerShellExecutor { get; } =
            new PowerShellExecutor();
        
        private static readonly Lazy<Startup> Lazy =
            new Lazy<Startup>(() => new Startup());

        public static Startup Instance => Lazy.Value;

        private Startup()
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