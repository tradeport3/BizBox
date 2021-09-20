using Domain.Common;

namespace Domain.Models
{
    public class Salary : ValueObject
    {
        public Salary(string position, string netSalary)
        {
            Validatr.Validate(position);
            Validatr.Validate(netSalary);

            this.Position = position;
            this.NetSalary = netSalary;
        }
        public string Position { get; }

        public string NetSalary { get; }
    }
}