using System;
using System.Collections.Generic;
using Base_to_Model.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace Base_to_Model.Models;

public partial class PersonnesDbContext : DbContext
{
    public PersonnesDbContext()
    {
    }

    public PersonnesDbContext(DbContextOptions<PersonnesDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Personne> Personnes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySQL("Server=localhost;Database=personnes;User=root;Password=");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Personne>(entity =>
        {
            entity.HasKey(e => e.IdPersonne).HasName("PRIMARY");

            entity.ToTable("personnes");

            entity.Property(e => e.IdPersonne)
                .HasColumnType("int(11)")
                .HasColumnName("idPersonne");
            entity.Property(e => e.Age).HasColumnType("int(11)");
            entity.Property(e => e.Nom)
                .HasMaxLength(50)
                .HasColumnName("nom");
            entity.Property(e => e.Prenom)
                .HasMaxLength(50)
                .HasColumnName("prenom");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
