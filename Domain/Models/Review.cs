using Domain.Common;

namespace Domain.Models
{
    public class Review : Audit, IAggregateRoot
    {
        private readonly HashSet<Salary> salaries;
        private readonly HashSet<ProCon> prosCons;

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
            this.CompensationsBenefits = compensationsBenefits;
            this.CarreerOpportunities = carreerOpportunities;
            this.Culture = culture;

            this.salaries = new HashSet<Salary>();
            this.prosCons = new HashSet<ProCon>();
        }

        public double Management { get; set; }

        public double CompensationsBenefits { get; set; }

        public double CarreerOpportunities { get; set; }

        public double Culture { get; set; }

        public double Rating => this.GetRating();

        public IReadOnlyCollection<Salary> Salaries => this.salaries.ToList().AsReadOnly();

        public IReadOnlyCollection<ProCon> ProsCons => this.prosCons.ToList().AsReadOnly();

        public void AddSalary(Salary salary)
        {
            Validator.Validate(salary.Position);
            Validator.Validate(salary.NetSalary);

            this.salaries.Add(salary);
        }

        public void AddProCon(ProCon proCon)
        {
            Validator.Validate(proCon.Text);

            this.prosCons.Add(proCon);
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
