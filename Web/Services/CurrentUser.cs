using Application.Interfaces;
using System.Security.Claims;

namespace Web.Services
{
    public class CurrentUser : ICurrentUser
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public CurrentUser(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public string? Id => this.httpContextAccessor
            .HttpContext?
            .User?
            .FindFirstValue(ClaimTypes.NameIdentifier);

        public IEnumerable<string>? Roles { get; }
    }
}
