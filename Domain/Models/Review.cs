using Domain.Common;

namespace Domain.Models
{
    public class Review : Audit, IAggregateRoot
    {
        private readonly HashSet<Salary> salaries;
        private readonly HashSet<Comment> comments;

        public Review(
            double culture,
            double managament,
            double compensationsBenefits,
            double carreerOpportunities)
        {
            Validatr.Validate(managament);
            Validatr.Validate(compensationsBenefits);
            Validatr.Validate(carreerOpportunities);
            Validatr.Validate(culture);

            this.Management = managament;
            this.CompensationsBenefits = compensationsBenefits;
            this.CarreerOpportunities = carreerOpportunities;
            this.Culture = culture;

            this.salaries = new HashSet<Salary>();
            this.comments = new HashSet<Comment>();
        }

        public double Management { get; }

        public double CompensationsBenefits { get; }

        public double CarreerOpportunities { get; }

        public double Culture { get; }

        public double Rating => this.GetRating();

        public IReadOnlyCollection<Salary> Salaries => this.salaries.ToList().AsReadOnly();

        public IReadOnlyCollection<Comment> Comments => this.comments.ToList().AsReadOnly();

        public void AddSalary(Salary salary)
        {
            Validatr.Validate(salary.Position);
            Validatr.Validate(salary.NetSalary);

            this.salaries.Add(salary);
        }

        public void AddComment(Comment comment)
        {
            Validatr.Validate(comment.Text);

            this.comments.Add(comment);
        }

        private double GetRating()
            => new List<double>
            {
                this.Management,
                this.CompensationsBenefits,
                this.CarreerOpportunities,
                this.Culture
            }
            .Average();
    }
}
