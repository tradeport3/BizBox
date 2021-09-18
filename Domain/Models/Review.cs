using Domain.Common;

namespace Domain.Models
{
    public class Review : Audit
    {
        private readonly HashSet<Salary> salaries;

        public Review()
        {
            this.salaries = new HashSet<Salary>();
        }

        public IReadOnlyCollection<Salary> Salaries => this.salaries.ToList().AsReadOnly();

    }
}
