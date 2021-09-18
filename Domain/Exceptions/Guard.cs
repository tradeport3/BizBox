using Domain.Constants;

namespace Domain.Exceptions
{
    public class Guard//<TException>
                      //where TException : BaseException, new()
    {
        public void ForValidUrl(string url)
        {
            if (url.Length <= ModelConstants.MaxUrlLength &&
                Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                return;
            }

            this.ThrowException<BaseException>($"{url} is not a valid URL.");
        }

        public void Against(bool condition, string message)
        {
            if (!condition)
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
