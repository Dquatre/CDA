using System;
using System.Collections.Generic;
using CrudModelControl.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace CrudModelControl.Models;

public partial class ProductDbContext : DbContext
{
    public ProductDbContext()
    {
    }

    public ProductDbContext(DbContextOptions<ProductDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySQL("Name=Default");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.IdProduct).HasName("PRIMARY");

            entity.ToTable("products");

            entity.Property(e => e.IdProduct)
                .HasColumnType("int(11)")
                .HasColumnName("idProduct");
            entity.Property(e => e.NameProduct)
                .HasMaxLength(50)
                .HasColumnName("nameProduct");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Quantity)
                .HasColumnType("int(11)")
                .HasColumnName("quantity");
            entity.Property(e => e.ReleaseDate)
                .HasColumnType("date")
                .HasColumnName("releaseDate");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
