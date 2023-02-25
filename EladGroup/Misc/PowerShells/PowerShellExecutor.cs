using System;
using System.Collections.Generic;
using System.IO;
using System.Management.Automation;

namespace EladGroup.Misc.PowerShells
{
    /// <summary>
    ///     Prerequisite:
    ///     Add the package: `Microsoft.PowerShell.5.1.ReferenceAssemblies`
    /// </summary>
    public class PowerShellExecutor
    {
        public static void Run(string scriptPath, params string[] args)
        {
            using (PowerShell ps = PowerShell.Create())
            {
                ps.AddScript(File.ReadAllText(scriptPath));

                // Add arguments to the command.
                foreach (string arg in args)
                {
                    ps.AddArgument(arg);
                }

                ICollection<PSObject> resultList = ps.Invoke();
                foreach (PSObject result in resultList)
                {
                    Console.WriteLine(result.ToString());
                }
            }
        }
    }
}
