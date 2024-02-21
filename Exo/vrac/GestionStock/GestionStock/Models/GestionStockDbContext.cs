using System;
using System.Collections.Generic;
using GestionStock.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace GestionStock.Models;

public partial class GestionStockDbContext : DbContext
{
    public GestionStockDbContext()
    {
    }

    public GestionStockDbContext(DbContextOptions<GestionStockDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Article> Articles { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Typesproduit> Typesproduits { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySQL("Server=localhost;Database=gestionstockdb;User=root;Password=;port=3306;ssl mode=none");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Article>(entity =>
        {
            entity.HasKey(e => e.IdArticle).HasName("PRIMARY");

            entity.ToTable("articles");

            entity.HasIndex(e => e.IdCategorie, "FK_Articles_Categories");

            entity.Property(e => e.IdArticle).HasColumnType("int(11)");
            entity.Property(e => e.IdCategorie).HasColumnType("int(11)");
            entity.Property(e => e.LibelleArticle).HasMaxLength(255);
            entity.Property(e => e.QuantiteStockee).HasColumnType("int(11)");

            entity.HasOne(d => d.TheCategory).WithMany(p => p.ListArticles)
                .HasForeignKey(d => d.IdCategorie)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Articles_Categories");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.IdCategorie).HasName("PRIMARY");

            entity.ToTable("categories");

            entity.HasIndex(e => e.IdTypeProduit, "FK_Categories_TypesProduits");

            entity.Property(e => e.IdCategorie).HasColumnType("int(11)");
            entity.Property(e => e.IdTypeProduit).HasColumnType("int(11)");
            entity.Property(e => e.LibelleCategorie).HasMaxLength(50);

            entity.HasOne(d => d.TheTypesproduit).WithMany(p => p.ListCategories)
                .HasForeignKey(d => d.IdTypeProduit)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Categories_TypesProduits");
        });

        modelBuilder.Entity<Typesproduit>(entity =>
        {
            entity.HasKey(e => e.IdTypeProduit).HasName("PRIMARY");

            entity.ToTable("typesproduits");

            entity.Property(e => e.IdTypeProduit).HasColumnType("int(11)");
            entity.Property(e => e.LibelleTypeProduit).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
