using Application.Interfaces;
using System.Security.Claims;

namespace Web.Services
{
    public class CurrentUser : ICurrentUser
    {
        public CurrentUser(IHttpContextAccessor httpContextAccessor)
        {
            var user = httpContextAccessor.HttpContext?.User;

            if (user == null)
            {
                throw new InvalidOperationException("This request does not have an authenticated user.");
            }

            this.Id = user.FindFirstValue(ClaimTypes.NameIdentifier);

            this.Roles = user
                .FindAll(c => c.Type == ClaimTypes.Role)
                .Select(c => c.Value);
        }

        public string Id { get; }

        public IEnumerable<string> Roles { get; }
    }
}
