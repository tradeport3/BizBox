using Domain.Common;
using Domain.Constants;
using Domain.Exceptions;

namespace Domain.Models
{
    public class Company : Audit, IAggregateRoot
    {
        private readonly HashSet<Review> reviews;
        private readonly HashSet<Interview> interviews;

        public Company(string name)
        {
            this.Validate(name);

            this.Name = name;
            this.reviews = new HashSet<Review>();
            this.interviews = new HashSet<Interview>();
        }

        public string Name { get; set; }

        public int Rating => (int)this.reviews.Average(x => x.Rating);

        public IReadOnlyCollection<Review> Reviews => this.reviews.ToList().AsReadOnly();

        public IReadOnlyCollection<Interview> Interviews => this.interviews.ToList().AsReadOnly();

        public void AddReview(Review review) => this.reviews.Add(review);

        public void AddInterview(Interview interview) => this.interviews.Add(interview);

        public Company UpdateName(string name)
        {
            this.Validate(name);

            this.Name = name;

            return this;
        }

        private void Validate(string value)
        {
            Guard.AgainstInValidString(value, ErrorConstants.InvalidInput);

            Guard.Against(
                value.Length < ModelConstants.MinStringLength ||
                value.Length > ModelConstants.MaxStringLength,
                ErrorConstants.InvalidInput);
        }
    }
}
