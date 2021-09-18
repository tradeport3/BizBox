using Domain.Models;

namespace Domain.Repositories
{
    public interface ICompanyRepository : IRepository<Company>
    {
        Task<Company> Find(int id, CancellationToken cancellationToken = default);
    }
}
