using System.Collections.Generic;

namespace Infrastructure.Identity
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user, IEnumerable<string> roles);
    }
}
