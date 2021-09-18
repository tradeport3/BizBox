using Domain.Common;
using Domain.Models;

namespace Domain.Factories.Reviews
{
    public interface IReviewFactory : IFactory<Review>
    {
        IReviewFactory WithRating(double rating);
    }
}
