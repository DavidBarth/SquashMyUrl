using Microsoft.EntityFrameworkCore;
using SquashMyUrlApp.Models;

namespace SquashMyUrl.DAL
{
    internal class SquashMyUrlContext : DbContext
    {
        public SquashMyUrlContext(DbContextOptions<SquashMyUrlContext> options) : base(options)
        {
        }

        public DbSet<SquashModel> SquashModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SquashModel>().ToTable("Url");
        }
    }
}
