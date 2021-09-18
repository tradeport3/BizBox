using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance
{
    internal class BizBoxDbContext : IdentityDbContext<IdentityUser>
    {
        public BizBoxDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; } = default!;

        public DbSet<Review> Reviews { get; set; } = default!;

        public DbSet<Salary> Salaries { get; set; } = default!;

        public DbSet<Interview> Interviews { get; set; } = default!;
    }
}
