using System;
using EladGroup.Logics;
using EladGroup.Misc;

namespace EladGroup._Console
{
    internal class CityConsole
    {
        private CityLogic CityLogic { get; } = new CityLogic();

        public void Get()
        {
            CityLogic.Get().ForEach(city =>
                Console.WriteLine(city.ToStringExtension()));
        }
    }
}