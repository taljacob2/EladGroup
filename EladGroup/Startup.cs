using EladGroup.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EladGroup
{
    internal class Startup
    {
        public ConnectionInitiator ConnectionInitiator { get; } = ConnectionInitiator.Instance;
    }
}
