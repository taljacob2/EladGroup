using System.Collections.Generic;
using EladGroup.Models;

namespace EladGroup.Repositories.Cities
{
    internal interface ICityRepository : 
    {
        void Insert(string name, int priority);
        List<City> Get();
        List<City> GetOrderByPriority();
    }
}