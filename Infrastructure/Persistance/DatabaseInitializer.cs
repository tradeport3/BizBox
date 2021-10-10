using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance
{
    internal class DatabaseInitializer : IInitializer
    {
        private readonly BizBoxDbContext db;

        public DatabaseInitializer(BizBoxDbContext db)
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
