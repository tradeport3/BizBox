using Domain.Common;

namespace Domain.Models
{
    public class Company : Audit, IAggregateRoot
    {
        private readonly HashSet<Review> reviews;
        private readonly HashSet<Interview> interviews;

        public Company(string name)
        {
            Validatr.Validate(name);

            this.Name = name;

            this.reviews = new HashSet<Review>();
            this.interviews = new HashSet<Interview>();
        }

        public string Name { get; private set; }

        public double Rating => this.reviews.Average(x => x.Rating);

        public IReadOnlyCollection<Review> Reviews => this.reviews.ToList().AsReadOnly();

        public IReadOnlyCollection<Interview> Interviews => this.interviews.ToList().AsReadOnly();

        public void AddReview(Review review)
        {
            Validatr.Validate(review.Management);
            Validatr.Validate(review.Perks);
            Validatr.Validate(review.CareerGrowth);
            Validatr.Validate(review.Culture);

            this.reviews.Add(review);
        }

        public void AddInterview(Interview interview) => this.interviews.Add(interview);

        public Company UpdateName(string name)
        {
            Validatr.Validate(name);

            this.Name = name;

            return this;
        }
    }
}
