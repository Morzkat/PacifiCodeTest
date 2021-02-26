using KHahn.ApplicationProcess.February2021.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace KHahn.ApplicationProcess.February2021.Data.DataAccess
{
    public class KHahnApplicationProcessContext : DbContext
    {
        public virtual DbSet<Asset> Assets { get; set; }

        public KHahnApplicationProcessContext(DbContextOptions<KHahnApplicationProcessContext> options) : base(options)
        {
        }

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        // }
    }
}