using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using TwoWaySynonyms.DAO.Models;
using TwoWaySynonyms.Infrastructure.Database.Configuration;

namespace TwoWaySynonyms.Infrastructure.Database
{
    public class TwoWaySynonymsDbContext : DbContext
    {
        public DbSet<TermDAO> Terms { get; set; }


        public TwoWaySynonymsDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new TermConfiguration());
        }
    }
}
