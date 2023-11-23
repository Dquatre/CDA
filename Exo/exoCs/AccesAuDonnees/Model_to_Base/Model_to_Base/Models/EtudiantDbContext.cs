using Microsoft.EntityFrameworkCore;
using Model_to_Base.Models.Data;

namespace Model_to_Base.Models
{
    public class EtudiantDbContext : DbContext
    {
        public DbSet<Etudiants> Etudiants { get; set; }
        public EtudiantDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Etudiants>(e => e.Property(o =>
                o.Age).HasColumnType("int(1)").HasConversion<short>());

        }
    }
}
