using System;
using System.Data.SqlClient;
using EladGroup.Misc.Connections;

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
    }
}
