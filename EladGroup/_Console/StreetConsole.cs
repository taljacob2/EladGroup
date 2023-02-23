using System;
using EladGroup.Logics;
using EladGroup.Misc;

namespace EladGroup._Console
{
    internal class StreetConsole
    {
        private StreetLogic StreetLogic { get; } = new StreetLogic();

        public void Get()
        {
            StreetLogic.Get()
                .ForEach(street => Console.WriteLine(street.ToStringExtension()));
        }
    }
}