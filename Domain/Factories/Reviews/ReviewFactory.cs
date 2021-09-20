using Domain.Models;

namespace Domain.Factories.Reviews
{
    internal class ReviewFactory : IReviewFactory
    {
        private double management = default!;
        private double perks = default!;
        private double careerGrowth = default!;
        private double culture = default!;

        public IReviewFactory WithManagement(double management)
        {
            this.management = management;
            return this;
        }
        public IReviewFactory WithPerks(double perks)
        {
            this.perks = perks;
            return this;
        }
        public IReviewFactory WithCareerGrowth(double careerGrowth)
        {
            this.careerGrowth = careerGrowth;
            return this;
        }
        public IReviewFactory WithCulture(double culture)
        {
            this.culture = culture;
            return this;
        }

        public Review Create()
            => new(this.management,
                   this.perks,
                   this.careerGrowth,
                   this.culture);
    }
}
