using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance
{
    internal class DbInitializer : IInitializer
    {
        private readonly BizBoxDbContext db;

        public DbInitializer(BizBoxDbContext db)
        {
            this.db = db;
        }

        public void Initialize()
        {
            this.db.Database.Migrate();

            this.db.SaveChanges();
        }
    }
}
