using Domain.Models;

namespace Domain.Repositories
{
    public interface IReviewRepository : IRepository<Review>
    {
        Task<Review> Find(int id, CancellationToken cancellationToken = default);
    }
}
