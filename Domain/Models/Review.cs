using Domain.Common;
using Domain.Constants;
using Domain.Exceptions;

namespace Domain.Models
{
    public class Review : Audit
    {
        private readonly HashSet<Salary> salaries;

        public Review(int rating)
        {
            Validate(rating);

            this.Rating = rating;
            this.salaries = new HashSet<Salary>();
        }

        public int Rating { get; set; }

        public IReadOnlyCollection<Salary> Salaries => this.salaries.ToList().AsReadOnly();

        public void AddSalary(Salary salary) => this.salaries.Add(salary);

        private void Validate(int value)
            => Guard.Against(
                  value < ModelConstants.MinRating ||
                  value > ModelConstants.MaxRating,
                  ErrorConstants.InvalidInput);

    }
}
