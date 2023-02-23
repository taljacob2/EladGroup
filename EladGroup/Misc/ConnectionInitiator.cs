using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace EladGroup.Misc
{
    /// <summary>
    /// Prerequisite: Add `System.Configuration` as Reference.
    /// Singleton implementation.
    /// </summary>
    public sealed class ConnectionInitiator
    {
        private ConnectionInitiator()
        {
        }

        private static readonly Lazy<ConnectionInitiator> Lazy =
            new Lazy<ConnectionInitiator>(() => new ConnectionInitiator());

        public static ConnectionInitiator Instance => Lazy.Value;

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
                Console.WriteLine(cs.Name);
                Console.WriteLine(cs.ProviderName);
                Console.WriteLine(cs.ConnectionString);
            }
        }
    }
}