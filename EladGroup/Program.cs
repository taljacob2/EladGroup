using EladGroup.Misc.PowerShells;

namespace EladGroup
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Startup.Instance.InitDatabase();

            // new MainConsole().Run();
        }
    }
}
