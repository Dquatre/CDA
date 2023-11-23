using System;
using System.Collections.Generic;
using ApiPersonne.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPersonne.Data;

public partial class PersonneDbContext : DbContext
{
    public PersonneDbContext()
    {
    }

    public PersonneDbContext(DbContextOptions<PersonneDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Personne> Personnes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySQL("Name=Default");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Personne>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("personnes");

            entity.HasIndex(e => e.Prenom, "prenom_id");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Adresse)
                .HasMaxLength(50)
                .HasColumnName("adresse");
            entity.Property(e => e.CodePostal)
                .HasColumnType("int(11)")
                .HasColumnName("codePostal");
            entity.Property(e => e.Nom)
                .HasMaxLength(45)
                .HasColumnName("nom");
            entity.Property(e => e.Prenom)
                .HasMaxLength(20)
                .HasColumnName("prenom");
            entity.Property(e => e.Ville)
                .HasMaxLength(20)
                .HasColumnName("ville");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
