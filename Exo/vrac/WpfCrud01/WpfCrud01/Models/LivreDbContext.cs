using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WpfCrud01.Models.Data;

namespace WpfCrud01.Models;

public partial class LivreDbContext : DbContext
{
    public LivreDbContext()
    {
    }

    public LivreDbContext(DbContextOptions<LivreDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Livre> Livres { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySQL("Server=localhost;Database=livre;User=root;Password=;port=3306;ssl mode=none");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Livre>(entity =>
        {
            entity.HasKey(e => e.IdLivre).HasName("PRIMARY");

            entity.ToTable("livre");

            entity.Property(e => e.IdLivre)
                .HasColumnType("int(11)")
                .HasColumnName("idLivre");
            entity.Property(e => e.Auteur)
                .HasMaxLength(50)
                .HasColumnName("auteur");
            entity.Property(e => e.Editeur)
                .HasMaxLength(50)
                .HasColumnName("editeur");
            entity.Property(e => e.NombrePage)
                .HasColumnType("int(11)")
                .HasColumnName("nombrePage");
            entity.Property(e => e.TitreLivre)
                .HasMaxLength(50)
                .HasColumnName("titreLivre");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
