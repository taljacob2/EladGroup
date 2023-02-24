using EladGroup.Misc.PowerShells;

namespace EladGroup
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // TODO: Check ps1 script path.
            Startup.Instance.InitDatabase();

            // new MainConsole().Run();
        }
    }
}
