using Domain.Common;
using Domain.Constants;
using Domain.Exceptions;

namespace Domain.Models
{
    public class Salary : ValueObject
    {
        public Salary(string position)
        {
            Validate(position);

            this.Position = position;
        }
        public string Position { get; set; }

        private void Validate(string value)
        {
            Guard.AgainstInValidString(value, ErrorConstants.InvalidInput);

            Guard.Against(
                        value.Length < ModelConstants.MinStringLength ||
                        value.Length > ModelConstants.MaxStringLength,
                        ErrorConstants.InvalidInput);
        }
    }
}