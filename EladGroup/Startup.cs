﻿using System;
using System.Data.SqlClient;
using EladGroup.Misc;
using EladGroup.Misc._PowerShell;
using EladGroup.Misc.Connections;

namespace EladGroup
{
    /// <summary>
    ///     Singleton implementation.
    ///     References:
    ///     https://www.c-sharpcorner.com/UploadFile/8911c4/singleton-design-pattern-in-C-Sharp/
    /// </summary>
    internal sealed class Startup
    {
        private static readonly Lazy<Startup> Lazy =
            new Lazy<Startup>(() => new Startup());

        private Startup()
        {
            // Open connection at the end of the initialization.
            TestConnection();
        }

        public ConnectionInitiator ConnectionInitiator { get; } =
            ConnectionInitiator.Instance;

        private PowerShellExecutor PowerShellExecutor { get; } =
            new PowerShellExecutor();

        public static Startup Instance => Lazy.Value;

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
        ///     Make sure you have
        ///     <a
        ///         href="https://docs.microsoft.com/en-us/sql/tools/sqlcmd-utility?view=sql-server-ver15">
        ///         sqlcmd
        ///     </a>
        ///     installed, to allow queries to the database through the cli.
        ///     It may be already installed on your computer.
        ///     You can check this by running:
        ///     <code>
        /// sqlcmd -?
        /// </code>
        /// </summary>
        public void InitDatabase()
        {
            PowerShellExecutor.Run("InitDatabase.ps1");
        }
    }
}
