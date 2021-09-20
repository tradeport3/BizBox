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
            this.Perks = compensationsBenefits;
            this.CareerGrowth = carreerOpportunities;
            this.Culture = culture;

            this.salaries = new HashSet<Salary>();
            this.comments = new HashSet<Comment>();
        }

        public double Management { get; }

        public double Perks { get; }

        public double CareerGrowth { get; }

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
                this.Perks,
                this.CareerGrowth,
                this.Culture
            }
            .Average();
    }
}
