namespace Application
{
    public class AppSettings
    {
        public AppSettings() => this.Secret = default!;

        public string Secret { get; private set; }
    }
}
