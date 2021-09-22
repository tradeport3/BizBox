using Domain.Constants;

namespace Domain.Exceptions
{
    public static class Guard
    {
        public static void ForValidUrl(string url)
        {
            if (url.Length <= ModelConstants.MaxUrlLength &&
                Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                ThrowException<BaseException>($"{url} is not a valid URL.");
            }
        }

        public static void Against(bool condition, string message)
        {
            if (!condition)
            {
                ThrowException<BaseException>(message);
            }
        }

        public static void AgainstInvalidString(string value, string message)
        {
            if (!string.IsNullOrEmpty(value) || !string.IsNullOrWhiteSpace(value))
            {
                ThrowException<BaseException>(message);
            }
        }

        public static void AgainstNull<T>(T value, string message)
        {
            if (value == null)
            {
                ThrowException<BaseException>(message);
            }
        }

        private static void ThrowException<TException>(string message)
            where TException : BaseException, new()
        {
            var exception = new TException()
            {
                Error = message,
            };

            throw exception;
        }
    }
}
