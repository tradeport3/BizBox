using Domain.Common;
using Domain.Constants;
using Domain.Exceptions;

namespace Domain.Models
{
    public class Review : Audit
    {
        private readonly HashSet<Salary> salaries;

        public Review()
        {
            this.salaries = new HashSet<Salary>();
        }

        public int Rating { get; set; }

        public IReadOnlyCollection<Salary> Salaries => this.salaries.ToList().AsReadOnly();

        public void AddSalary(Salary salary) => this.salaries.Add(salary);

        private void Validate(string rating)
        {
            Guard.AgainstInValidString(rating, ErrorConstants.InvalidInput);

            Guard.Against(
                        rating.Length < ModelConstants.MinRating ||
                        rating.Length > ModelConstants.MaxRating,
                        ErrorConstants.InvalidInput);

        }

    }
}
