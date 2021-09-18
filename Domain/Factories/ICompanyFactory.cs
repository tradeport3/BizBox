using Domain.Common;
using Domain.Models;

namespace Domain.Factories
{
    public interface ICompanyFactory : IFactory<Company>
    {
        ICompanyFactory WithName(string name);
    }
}
