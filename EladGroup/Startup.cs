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
        public ConnectionInitiator ConnectionInitiator { get; } =
            ConnectionInitiator.Instance;

        private PowerShellExecutor PowerShellExecutor { get; } =
            new PowerShellExecutor();

        private static readonly Lazy<Startup> Lazy =
            new Lazy<Startup>(() => new Startup());

        public static Startup Instance => Lazy.Value;

        private Startup()
        {
            // Open connection at the end of the initialization.
            TestConnection();
        }

        private void TestConnection()
        {
            try
            {
                Console.WriteLine("Opening Connection ...");

                // Create a connection, and open it.
                new SqlConnection(ConnectionInitiator.ConnectionString).Open();

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