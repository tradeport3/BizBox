using Domain.Models;

namespace Domain.Factories.Companies
{
    internal class CompanyFactory : ICompanyFactory
    {
        private string name = default!;

        public ICompanyFactory WithName(string name)
        {
            this.name = name;
            return this;
        }
        public Company Create() => new(this.name);
    }
}
