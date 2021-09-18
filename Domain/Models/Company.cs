using Domain.Common;
using Domain.Constants;
using Domain.Exceptions;

namespace Domain.Models
{
    public class Company : Audit, IAggregateRoot
    {
        private readonly HashSet<Review> reviews;

        public Company(string name)
        {
            this.Validate(name);

            this.Name = name;
            this.reviews = new HashSet<Review>();
        }

        public string Name { get; set; }

        public int Rating => (int)this.reviews.Average(x => x.Rating);

        public IReadOnlyCollection<Review> Reviews => this.reviews.ToList().AsReadOnly();

        public Company UpdateName(string name)
        {
            this.Validate(name);
            this.Name = name;

            return this;
        }


        public void AddReview(Review review) => this.reviews.Add(review);

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
