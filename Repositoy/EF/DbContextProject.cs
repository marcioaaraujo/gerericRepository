using Microsoft.EntityFrameworkCore;
using Repository.Entities;

namespace Repository.EF
{
    public class DbContextProject : DbContext
    {
        public DbContextProject(DbContextOptions<DbContextProject> options) : base(options) {}
      
        public DbSet<People> People { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
