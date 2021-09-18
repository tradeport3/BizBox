using Application.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class User : IdentityUser, IUser
    {
    }
}
