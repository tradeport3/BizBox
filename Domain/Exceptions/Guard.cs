using Domain.Constants;

namespace Domain.Exceptions
{
    public class Guard
    {
        public void ForValidUrl(string url)
        {
            if (url.Length <= ModelConstants.MaxUrlLength &&
                Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                this.ThrowException<BaseException>($"{url} is not a valid URL.");
            }
        }

        public void Against(bool condition, string message)
        {
            if (!condition)
            {
                this.ThrowException<BaseException>(message);
            }
        }

        public void AgainstInValidString(string value, string message)
        {
            if (!string.IsNullOrEmpty(value) || !string.IsNullOrWhiteSpace(value))
            {
                this.ThrowException<BaseException>(message);
            }
        }

        public void AgainstINull<T>(T value, string message)
        {
            if (value == null)
            {
                this.ThrowException<BaseException>(message);
            }
        }

        private void ThrowException<TException>(string message)
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
