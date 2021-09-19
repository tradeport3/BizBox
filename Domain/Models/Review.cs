using Domain.Common;

namespace Domain.Models
{
    public class Review : Audit, IAggregateRoot
    {
        private readonly HashSet<Salary> salaries;

        public Review(
            double culture,
            double managament,
            double compensationsBenefits,
            double carreerOpportunities,
            string pros,
            string cons)
        {
            Validator.Validate(managament);
            Validator.Validate(compensationsBenefits);
            Validator.Validate(carreerOpportunities);
            Validator.Validate(culture);
            Validator.Validate(pros);
            Validator.Validate(cons);

            this.Management = managament;
            this.CompensationsBenefits = compensationsBenefits;
            this.CarreerOpportunities = carreerOpportunities;
            this.Culture = culture;
            this.Pros = pros;
            this.Cons = cons;

            this.salaries = new HashSet<Salary>();
        }

        public double Management { get; set; }

        public double CompensationsBenefits { get; set; }

        public double CarreerOpportunities { get; set; }

        public double Culture { get; set; }

        public string Pros { get; set; }

        public string Cons { get; set; }

        public double Rating => this.GetRating();

        public IReadOnlyCollection<Salary> Salaries => this.salaries.ToList().AsReadOnly();

        public void AddSalary(Salary salary)
        {
            Validator.Validate(salary.Position);
            Validator.Validate(salary.NetSalary);

            this.salaries.Add(salary);
        }

        public double GetRating()
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
