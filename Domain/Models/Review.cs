using Domain.Common;
using Domain.Enums;

namespace Domain.Models
{
    public class Review : Entity<int>, IAggregateRoot
    {
        private readonly HashSet<Salary> salaries;
        private readonly HashSet<Comment> comments;

        public Review(
            double culture,
            double managament,
            double compensationsBenefits,
            double carreerOpportunities)
        {
            Validator.Validate(managament);
            Validator.Validate(compensationsBenefits);
            Validator.Validate(carreerOpportunities);
            Validator.Validate(culture);

            this.Management = managament;
            this.Perks = compensationsBenefits;
            this.CareerGrowth = carreerOpportunities;
            this.Culture = culture;

            this.salaries = new HashSet<Salary>();
            this.comments = new HashSet<Comment>();
        }

        public WriterType Writer { get; }

        public double Management { get; }

        public double Perks { get; }

        public double CareerGrowth { get; }

        public double Culture { get; }

        public double Rating => this.GetRating();

        public IReadOnlyCollection<Salary> Salaries => this.salaries.ToList().AsReadOnly();

        public IReadOnlyCollection<Comment> Comments => this.comments.ToList().AsReadOnly();

        public void AddSalary(Salary salary)
        {
            Validator.Validate(salary.Position);
            Validator.Validate(salary.NetSalary);

            this.salaries.Add(salary);
        }

        public void AddComment(Comment comment)
        {
            Validator.Validate(comment.Text);

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
