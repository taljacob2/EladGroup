using System.Collections.Generic;
using EladGroup.Models;

namespace EladGroup.Repositories.Streets
{
    internal interface IStreetRepository
    {
        void Insert(string name, int priority, int cityId);
        List<Street> Get();
        List<Street> GetOrderByPriority();
    }
}
