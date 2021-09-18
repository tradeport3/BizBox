using System.Reflection;
using Application.Interfaces;
using Domain.Common;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance
{
    internal class BizBoxDbContext : IdentityDbContext<IdentityUser>
    {
        private readonly ICurrentUser currentUser;

        public BizBoxDbContext(
            DbContextOptions options,
            ICurrentUser currentUser)
            : base(options)
        {
            this.currentUser = currentUser;
        }

        public DbSet<Company> Companies { get; set; } = default!;

        public DbSet<Review> Reviews { get; set; } = default!;

        public DbSet<Salary> Salaries { get; set; } = default!;

        public DbSet<Interview> Interviews { get; set; } = default!;

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            foreach (var entry in this.ChangeTracker.Entries<IAudit>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedOn = DateTime.UtcNow;
                        entry.Entity.CreatedBy ??= this.currentUser.Id;
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModifiedOn = DateTime.UtcNow;
                        entry.Entity.ModifiedBy ??= this.currentUser.Id;
                        break;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
