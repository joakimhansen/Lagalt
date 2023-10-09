using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Lagalt_backend.Data.Models.Entities;

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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:LagaltTestDb");
            }
        }

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

                entity.Property(e => e.CreatorName)
                    .HasMaxLength(25)
                    .HasColumnName("Creator_Name");

                entity.Property(e => e.FullDescription).HasColumnName("Full_Description");

                entity.Property(e => e.GithubUrl)
                    .HasMaxLength(100)
                    .HasColumnName("Github_Url");

                entity.Property(e => e.ShortDescription)
                    .HasMaxLength(500)
                    .HasColumnName("Short_Description");

                entity.Property(e => e.Title).HasMaxLength(40);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Project__Categor__6FE99F9F");

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.CreatorName)
                    .HasConstraintName("FK__Project__Creator__70DDC3D8");
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.ToTable("Skill");

                entity.Property(e => e.Name).HasMaxLength(25);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK__User__536C85E5AB6DD85D");

                entity.ToTable("User");

                entity.Property(e => e.Username).HasMaxLength(25);

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(30)
                    .HasColumnName("Image_url");

                entity.Property(e => e.Info).HasMaxLength(1000);

                entity.HasMany(d => d.Skills)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "UserSkillLink",
                        l => l.HasOne<Skill>().WithMany().HasForeignKey("SkillId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__UserSkill__Skill__76969D2E"),
                        r => r.HasOne<User>().WithMany().HasForeignKey("UserName").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__UserSkill__User___75A278F5"),
                        j =>
                        {
                            j.HasKey("UserName", "SkillId").HasName("UserSkillLink_Primary_Key");

                            j.ToTable("UserSkillLink");

                            j.IndexerProperty<string>("UserName").HasMaxLength(25).HasColumnName("User_Name");

                            j.IndexerProperty<int>("SkillId").HasColumnName("Skill_Id");
                        });
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
