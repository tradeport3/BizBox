using Domain.Common;
using Domain.Models;

namespace Domain.Factories.Companies
{
    public interface ICompanyFactory : IFactory<Company>
    {
        ICompanyFactory WithName(string name);
    }
}
