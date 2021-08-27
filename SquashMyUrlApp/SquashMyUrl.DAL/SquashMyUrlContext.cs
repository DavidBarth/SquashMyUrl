using Microsoft.EntityFrameworkCore;
using SquashMyUrlApp.Models;

namespace SquashMyUrl.DAL
{
    /// <summary>
    /// DB context for R/W operations
    /// </summary>
    public class SquashMyUrlContext : DbContext
    {
        public SquashMyUrlContext(DbContextOptions<SquashMyUrlContext> options) : base(options)
        {
        }

        public DbSet<UrlModel> UrlModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UrlModel>().ToTable("Url");
        }
    }
}
