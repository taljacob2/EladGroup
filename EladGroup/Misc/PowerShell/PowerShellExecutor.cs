﻿namespace EladGroup.Misc.PowerShell
{
    
    /// <summary>
    /// Prerequisite:
    /// Add the package: `Microsoft.PowerShell.SDK`
    /// </summary>
    public class PowerShellExecutor
    {
        public PowerShellExecutor()
        {
        }

        public void Run(string scriptPath, params string[] args)
        {
            using (PowerShell PowerShellInst = PowerShell.Create())
            {
                PowerShell ps = PowerShell.Create();

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