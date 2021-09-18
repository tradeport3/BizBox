using Domain.Common;
using Domain.Constants;
using Domain.Exceptions;

namespace Domain.Models
{
    public class Company : Audit, IAggregateRoot
    {
        private readonly Guard guard;

        private readonly HashSet<Review> reviews;

        public Company(Guard guard)
        {
            this.guard = guard;

            this.reviews = new HashSet<Review>();
        }

        public string Name { get; private set; }

        public int Rating { get; private set; }

        public IReadOnlyCollection<Review> Reviews => this.reviews.ToList().AsReadOnly();

        public Company UpdateName(string name)
        {
            this.Validate(name);
            this.Name = name;

            return this;
        }

        public void AddReview(Review review) => this.reviews.Add(review);

        private void Validate(string name)
         => this.guard.Against(
             name.Length < ModelConstants.MinNameLength ||
             name.Length > ModelConstants.MaxNameLength,
             ErrorConstants.InvalidInput);

    }
}
