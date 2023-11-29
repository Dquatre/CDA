using System;
using System.Collections.Generic;
using ApiGame.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiGame.Data;

public partial class ConsoleDbContext : DbContext
{
    public ConsoleDbContext()
    {
    }

    public ConsoleDbContext(DbContextOptions<ConsoleDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Game> Games { get; set; }

    public virtual DbSet<GameConsole> GameConsoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySQL("Name=Default");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Game>(entity =>
        {
            entity.HasKey(e => e.IdGame).HasName("PRIMARY");

            entity.ToTable("games");

            entity.HasIndex(e => e.IdGameConsole, "idGameConsole");

            entity.Property(e => e.IdGame)
                .HasColumnType("int(11)")
                .HasColumnName("idGame");
            entity.Property(e => e.AnneeSortie)
                .HasColumnType("int(11)")
                .HasColumnName("anneeSortie");
            entity.Property(e => e.IdGameConsole)
                .HasColumnType("int(11)")
                .HasColumnName("idGameConsole");
            entity.Property(e => e.SousTitre)
                .HasMaxLength(50)
                .HasColumnName("sousTitre");
            entity.Property(e => e.Titre)
                .HasMaxLength(50)
                .HasColumnName("titre");

            entity.HasOne(d => d.IdGameConsoleNavigation).WithMany(p => p.Games)
                .HasForeignKey(d => d.IdGameConsole)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("games_ibfk_1");
        });

        modelBuilder.Entity<GameConsole>(entity =>
        {
            entity.HasKey(e => e.IdGameConsole).HasName("PRIMARY");

            entity.ToTable("game_consoles");

            entity.Property(e => e.IdGameConsole)
                .HasColumnType("int(11)")
                .HasColumnName("idGameConsole");
            entity.Property(e => e.AnneeSortie)
                .HasColumnType("int(11)")
                .HasColumnName("anneeSortie");
            entity.Property(e => e.Constructeur)
                .HasMaxLength(50)
                .HasColumnName("constructeur");
            entity.Property(e => e.Nom)
                .HasMaxLength(50)
                .HasColumnName("nom");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
