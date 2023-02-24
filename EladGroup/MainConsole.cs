using System;
using EladGroup.Consoles;

namespace EladGroup
{
    internal class MainConsole
    {
        private int LowestOption { get; } = 1;

        private int HighestOption { get; } = 5;

        private CityConsole CityConsole { get; } = new CityConsole();

        private StreetConsole StreetConsole { get; } = new StreetConsole();

        private void SwitchMenuPrint(int option)
        {
            switch (option)
            {
                case 1:
                    Console.WriteLine($"{option}. Insert a City entry.");
                    break;
                case 2:
                    Console.WriteLine($"{option}. Insert a Street entry.");
                    break;
                case 3:
                    Console.WriteLine(
                        $"{option}. Get all City entries, ordered by priority.");
                    break;
                case 4:
                    Console.WriteLine(
                        $"{option}. Get all Street entries of a given City, ordered by priority.");
                    break;
                case 5:
                    Console.WriteLine($"{option}. Exit program.");
                    break;
            }
        }

        private bool SwitchMenuRun(int option)
        {
            switch (option)
            {
                case 1:
                    CityConsole.Insert();
                    break;
                case 2:
                    StreetConsole.Insert();
                    break;
                case 3:
                    CityConsole.GetOrderByPriority();
                    break;
                case 4:
                    StreetConsole.GetByCityOrderByPriority();
                    break;
                case 5:
                    return false;
            }

            return true;
        }

        private int GetOptionFromInput()
        {
            string input = Console.ReadLine();
            if (!int.TryParse(input, out int option))
            {
                throw new Exception("Failed to parse `option`");
            }

            if (option > HighestOption || option < LowestOption)
            {
                throw new ArgumentOutOfRangeException("option",
                    "`option` is out of range");
            }

            return option;
        }

        public void Run()
        {
            for (int i = LowestOption; i <= HighestOption; i++)
            {
                SwitchMenuPrint(i);
            }

            int option = 0;
            try
            {
                option = GetOptionFromInput();
            }
            catch (Exception e)
            {
                Run();
                return;
            }

            bool runAgain = false;
            try
            {
                runAgain = SwitchMenuRun(option);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                runAgain = true;
            }

            if (runAgain)
            {
                Console.WriteLine();
                Run();
            }
        }
    }
}
