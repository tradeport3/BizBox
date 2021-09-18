using Domain.Common;
using Domain.Constants;
using Domain.Exceptions;

namespace Domain.Models
{
    public class Review : Audit, IAggregateRoot
    {
        private readonly HashSet<Salary> salaries;

        public Review(double rating)
        {
            Validate(rating);

            this.Rating = rating;
            this.salaries = new HashSet<Salary>();
        }

        public double Rating { get; set; }

        public IReadOnlyCollection<Salary> Salaries => this.salaries.ToList().AsReadOnly();

        public void AddSalary(Salary salary) => this.salaries.Add(salary);

        private void Validate(double value)
            => Guard.Against(
                  value < ModelConstants.MinRating ||
                  value > ModelConstants.MaxRating,
                  ErrorConstants.InvalidInput);

    }
}
