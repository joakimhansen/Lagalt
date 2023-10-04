using System;
using System.Collections.Generic;
using Lagalt_backend.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Lagalt_backend.Data.Models
{
    public partial class LagaltDbContext : DbContext
    {
        public LagaltDbContext()
        {
        }

        public LagaltDbContext(DbContextOptions<LagaltDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Project> Projects { get; set; } = null!;
        public virtual DbSet<Skill> Skills { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

       /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:LagaltTestDb");
            }
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Name).HasMaxLength(25);
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("Project");

                entity.Property(e => e.CategoryId).HasColumnName("Category_Id");

                entity.Property(e => e.CreatorId).HasColumnName("Creator_Id");

                entity.Property(e => e.FullDescription).HasColumnName("Full_Description");

                entity.Property(e => e.ShortDescription)
                    .HasMaxLength(500)
                    .HasColumnName("Short_Description");

                entity.Property(e => e.Title).HasMaxLength(40);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Project__Categor__3B75D760");

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.CreatorId)
                    .HasConstraintName("FK__Project__Creator__3C69FB99");
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.ToTable("Skill");

                entity.Property(e => e.Name).HasMaxLength(25);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Info).HasMaxLength(1000);

                entity.Property(e => e.Username).HasMaxLength(25);

                entity.HasMany(d => d.Skills)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "UserSkillLink",
                        l => l.HasOne<Skill>().WithMany().HasForeignKey("SkillId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__UserSkill__Skill__4222D4EF"),
                        r => r.HasOne<User>().WithMany().HasForeignKey("UserId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__UserSkill__User___412EB0B6"),
                        j =>
                        {
                            j.HasKey("UserId", "SkillId").HasName("UserSkillLink_Primary_Key");

                            j.ToTable("UserSkillLink");

                            j.IndexerProperty<int>("UserId").HasColumnName("User_Id");

                            j.IndexerProperty<int>("SkillId").HasColumnName("Skill_Id");
                        });
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
