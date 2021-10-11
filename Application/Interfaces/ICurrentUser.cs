namespace Application.Interfaces
{
    public interface ICurrentUser
    {
        string? Id { get; }

        IEnumerable<string>? Roles { get; }
    }
}
