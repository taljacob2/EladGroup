using System;
using System.Data.SqlClient;
using EladGroup.Misc.Connections;
using EladGroup.Misc.PowerShells;

namespace EladGroup
{
    /// <summary>
    ///     Bundles global startup settings for the program.
    ///     Singleton implementation.
    ///     References:
    ///     https://www.c-sharpcorner.com/UploadFile/8911c4/singleton-design-pattern-in-C-Sharp/
    /// </summary>
    internal sealed class Startup
    {
        private static readonly Lazy<Startup> Lazy =
            new Lazy<Startup>(() => new Startup());

        /// <summary>
        ///     Reassures there is a connection to the database, before allowing the use of
        ///     this class.
        /// </summary>
        /// <exception cref="Exception">
        ///     In case a connection to the database could not be established.
        /// </exception>
        private Startup()
        {
            TestConnection();
        }

        public ConnectionInitiator ConnectionInitiator { get; } =
            ConnectionInitiator.Instance;

        private PowerShellExecutor PowerShellExecutor { get; } =
            new PowerShellExecutor();

        public static Startup Instance => Lazy.Value;

        /// <summary>
        ///     Tests a connection to the database.
        /// </summary>
        /// <exception cref="Exception">
        ///     In case a connection to the database could not be established.
        /// </exception>
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
                throw new Exception("Error: " + e.Message);
            }
        }

        /// <summary>
        ///     Run this to initialize the database on your local machine.
        ///     Make sure you have
        ///     <a
        ///         href="https://docs.microsoft.com/en-us/sql/tools/sqlcmd-utility?view=sql-server-ver15">
        ///         sqlcmd
        ///     </a>
        ///     installed, to allow queries to the database through the cli.
        ///     It may be already installed on your computer.
        ///     You can check this by running:
        ///     <code>
        ///     sqlcmd -?
        ///     </code>
        /// </summary>
        public void InitDatabase()
        {
            PowerShellExecutor.Run("..\\..\\InitDatabase.ps1");
        }
    }
}
