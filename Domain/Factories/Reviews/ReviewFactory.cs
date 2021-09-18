using Domain.Models;

namespace Domain.Factories.Reviews
{
    internal class ReviewFactory : IReviewFactory
    {
        private double rating = default!;
        public IReviewFactory WithRating(double rating)
        {
            this.rating = rating;
            return this;
        }
        public Review Create() => new(this.rating);
    }
}
