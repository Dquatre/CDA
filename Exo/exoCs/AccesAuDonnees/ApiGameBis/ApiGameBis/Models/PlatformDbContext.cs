using System;
using System.Collections.Generic;
using ApiGameBis.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiGameBis.Models;

public partial class PlatformDbContext : DbContext
{
    public PlatformDbContext()
    {
    }

    public PlatformDbContext(DbContextOptions<PlatformDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Game> Games { get; set; }

    public virtual DbSet<GamesPlatform> GamesPlatforms { get; set; }

    public virtual DbSet<Platform> Platforms { get; set; }

    public virtual DbSet<Serie> Series { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySQL("Name=Default");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Game>(entity =>
        {
            entity.HasKey(e => e.IdGame).HasName("PRIMARY");

            entity.ToTable("games");

            entity.HasIndex(e => e.IdSerie, "FK_game_serie");

            entity.Property(e => e.IdGame)
                .HasColumnType("int(11)")
                .HasColumnName("idGame");
            entity.Property(e => e.IdSerie)
                .HasColumnType("int(11)")
                .HasColumnName("idSerie");
            entity.Property(e => e.ReleaseYear)
                .HasColumnType("int(11)")
                .HasColumnName("releaseYear");
            entity.Property(e => e.SubTitle)
                .HasMaxLength(50)
                .HasColumnName("subTitle");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasColumnName("title");

            entity.HasOne(d => d.GameSerie).WithMany(p => p.ListGames)
                .HasForeignKey(d => d.IdSerie)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_game_serie");
        });

        modelBuilder.Entity<GamesPlatform>(entity =>
        {
            entity.HasKey(e => e.IdGamePlatform).HasName("PRIMARY");

            entity.ToTable("games_platforms");

            entity.HasIndex(e => e.IdGame, "FK_games_games_platforms");

            entity.HasIndex(e => e.IdPlatform, "FK_platforms_games_platforms");

            entity.Property(e => e.IdGamePlatform)
                .HasColumnType("int(11)")
                .HasColumnName("idGame_Platform");
            entity.Property(e => e.IdGame)
                .HasColumnType("int(11)")
                .HasColumnName("idGame");
            entity.Property(e => e.IdPlatform)
                .HasColumnType("int(11)")
                .HasColumnName("idPlatform");

            entity.HasOne(d => d.PlatformGame).WithMany(p => p.ListGamesPlatforms)
                .HasForeignKey(d => d.IdGame)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_games_games_platforms");

            entity.HasOne(d => d.GamePlatform).WithMany(p => p.ListGamesPlatforms)
                .HasForeignKey(d => d.IdPlatform)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_platforms_games_platforms");
        });

        modelBuilder.Entity<Platform>(entity =>
        {
            entity.HasKey(e => e.IdPlatform).HasName("PRIMARY");

            entity.ToTable("platforms");

            entity.Property(e => e.IdPlatform)
                .HasColumnType("int(11)")
                .HasColumnName("idPlatform");
            entity.Property(e => e.Constructor)
                .HasMaxLength(50)
                .HasColumnName("constructor");
            entity.Property(e => e.PlatformName)
                .HasMaxLength(50)
                .HasColumnName("platformName");
        });

        modelBuilder.Entity<Serie>(entity =>
        {
            entity.HasKey(e => e.IdSerie).HasName("PRIMARY");

            entity.ToTable("series");

            entity.Property(e => e.IdSerie)
                .HasColumnType("int(11)")
                .HasColumnName("idSerie");
            entity.Property(e => e.SerieName)
                .HasMaxLength(50)
                .HasColumnName("serieName");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
