using Domain.Common;
using Domain.Models;

namespace Domain.Factories.Reviews
{
    public interface IReviewFactory : IFactory<Review>
    {
        IReviewFactory WithManagement(double rating);
        IReviewFactory WithPerks(double rating);
        IReviewFactory WithCareerGrowth(double rating);
        IReviewFactory WithCulture(double rating);
    }
}
