using System;
using System.Collections.Generic;
using ApiMinetesme.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiMinetesme.Data;

public partial class PantalonDbContext : DbContext
{
    public PantalonDbContext()
    {
    }

    public PantalonDbContext(DbContextOptions<PantalonDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Pantalon> Pantalons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySQL("Name=Default");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pantalon>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("pantalons");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Couleur)
                .HasMaxLength(50)
                .HasColumnName("couleur");
            entity.Property(e => e.Marque)
                .HasMaxLength(50)
                .HasColumnName("marque");
            entity.Property(e => e.Taille)
                .HasColumnType("int(11)")
                .HasColumnName("taille");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
