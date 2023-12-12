using System;
using System.Collections.Generic;
using CrudWithBdd.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace CrudWithBdd.Models;

public partial class ComplexDbContext : DbContext
{
    public ComplexDbContext()
    {
    }

    public ComplexDbContext(DbContextOptions<ComplexDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Salle> Batiments { get; set; }

    public virtual DbSet<Salle> Salles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySQL("Server=localhost;Database=complexdb;User=root;Password=;port=3306;ssl mode=none");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Salle>(entity =>
        {
            entity.HasKey(e => e.IdBatiment).HasName("PRIMARY");

            entity.ToTable("batiment");

            entity.Property(e => e.IdBatiment)
                .HasColumnType("int(11)")
                .HasColumnName("idBatiment");
            entity.Property(e => e.NomBatiment)
                .HasMaxLength(50)
                .HasColumnName("nomBatiment");
        });

        modelBuilder.Entity<Salle>(entity =>
        {
            entity.HasKey(e => e.IdSalle).HasName("PRIMARY");

            entity.ToTable("salle");

            entity.HasIndex(e => e.IdBatimentSalle, "idBatiment");

            entity.Property(e => e.IdSalle).HasColumnType("int(11)");
            entity.Property(e => e.CodeSalle)
                .HasMaxLength(50)
                .HasColumnName("codeSalle");
            entity.Property(e => e.IdBatimentSalle)
                .HasColumnType("int(11)")
                .HasColumnName("idBatiment");
            entity.Property(e => e.NombrePlace)
                .HasColumnType("int(11)")
                .HasColumnName("nombrePlace");
            entity.Property(e => e.Surface)
                .HasColumnType("int(11)")
                .HasColumnName("surface");

            entity.HasOne(d => d.IdBatimentNavigation).WithMany(p => p.Salles)
                .HasForeignKey(d => d.IdBatiment)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("salle_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
