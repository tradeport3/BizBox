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

        private void Validate(string name)
        {
            Guard.AgainstInValidString(name, ErrorConstants.InvalidInput);

            Guard.Against(
                        name.Length < ModelConstants.MinNameLength ||
                        name.Length > ModelConstants.MaxNameLength,
                        ErrorConstants.InvalidInput);

        }
    }
}
