using System;
using System.Configuration;

namespace EladGroup.Misc
{
    /// <summary>
    ///     Prerequisite: Add `System.Configuration` as Reference.
    ///     Singleton implementation.
    ///     References:
    ///     https://www.c-sharpcorner.com/UploadFile/8911c4/singleton-design-pattern-in-C-Sharp/
    ///     https://learn.microsoft.com/en-us/dotnet/framework/data/adonet/connection-strings-and-configuration-files
    /// </summary>
    internal sealed class ConnectionInitiator
    {
        private static readonly Lazy<ConnectionInitiator> Lazy =
            new Lazy<ConnectionInitiator>(() => new ConnectionInitiator());

        private ConnectionInitiator()
        {
            // Initialize `ConnectionString`.
            string wholeConnectionString =
                GetConnectionStringByName("EladGroupEntities");

            string dataSourceConnectionString = wholeConnectionString.Substring
            (wholeConnectionString.IndexOf("data source",
                StringComparison.Ordinal));

            // Remote the quote mark after the string.
            dataSourceConnectionString =
                dataSourceConnectionString.Remove(
                    dataSourceConnectionString.Length - 1);

            ConnectionString = dataSourceConnectionString;
        }

        public static ConnectionInitiator Instance => Lazy.Value;

        public string ConnectionString { get; }

        public void GetConnectionStrings()
        {
            ConnectionStringSettingsCollection settings =
                ConfigurationManager.ConnectionStrings;

            if (settings == null)
            {
                return;
            }

            foreach (ConnectionStringSettings cs in settings)
            {
                Console.WriteLine("Name");
                Console.WriteLine(cs.Name);
                Console.WriteLine("ProviderName");
                Console.WriteLine(cs.ProviderName);
                Console.WriteLine("ConnectionString");
                Console.WriteLine(cs.ConnectionString);
            }
        }

        /// <summary>
        ///     Retrieve a connection string by specifying the name.
        ///     Assumes one connection string per name in the config file.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetConnectionStringByName(string name)
        {
            string returnValue = null;

            ConnectionStringSettingsCollection settings =
                ConfigurationManager.ConnectionStrings;

            if (settings == null)
            {
                return returnValue;
            }

            foreach (ConnectionStringSettings cs in settings)
            {
                if (cs.Name == name)
                {
                    returnValue = cs.ConnectionString;
                    break;
                }
            }

            return returnValue;
        }
    }
}
