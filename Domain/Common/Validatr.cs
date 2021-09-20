using Domain.Constants;
using Domain.Exceptions;

namespace Domain.Common
{
    internal static class Validatr
    {
        internal static void Validate(double value)
          => Guard.Against(
                value < ModelConstants.MinRating ||
                value > ModelConstants.MaxRating,
                ErrorConstants.InvalidInput);

        internal static void Validate(string value)
        {
            Guard.AgainstInvalidString(value, ErrorConstants.InvalidInput);

            Guard.Against(value.Length < ModelConstants.MinStringLength ||
                          value.Length > ModelConstants.MaxStringLength,
                          ErrorConstants.InvalidInput);
        }
    }
}
