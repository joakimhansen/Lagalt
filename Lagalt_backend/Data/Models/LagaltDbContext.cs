using System;
using System.Collections.Generic;
using Lagalt_backend.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Lagalt_backend.Data.Models {
    public partial class LagaltDbContext : DbContext {
        public LagaltDbContext() {
        }

        public LagaltDbContext(DbContextOptions<LagaltDbContext> options)
            : base(options) {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<CollaboratorApplication> CollaboratorApplications { get; set; } = null!;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Category>(entity => {
                entity.ToTable("Category");

                entity.Property(e => e.Name).HasMaxLength(25);
            });

            modelBuilder.Entity<CollaboratorApplication>(entity => {
                entity.ToTable("CollaboratorApplication");

                entity.Property(e => e.Content).HasMaxLength(200);

                entity.Property(e => e.User).HasMaxLength(25);

                entity.HasOne(d => d.ProjectNavigation)
                    .WithMany(p => p.CollaboratorApplications)
                    .HasForeignKey(d => d.Project)
                    .HasConstraintName("FK__Collabora__Proje__7E02B4CC");

                entity.HasOne(d => d.UserNavigation)
                    .WithMany(p => p.CollaboratorApplications)
                    .HasForeignKey(d => d.User)
                    .HasConstraintName("FK__Collaborat__User__7D0E9093");
            });

            modelBuilder.Entity<Project>(entity => {
                entity.ToTable("Project");

                entity.Property(e => e.CategoryId).HasColumnName("Category_Id");

                entity.Property(e => e.CreatorName)
                    .HasMaxLength(25)
                    .HasColumnName("Creator_Name");

                entity.Property(e => e.FullDescription)
                    .HasMaxLength(600)
                    .HasColumnName("Full_Description");

                entity.Property(e => e.GithubUrl)
                    .HasMaxLength(100)
                    .HasColumnName("Github_Url");

                entity.Property(e => e.Progress).HasDefaultValueSql("((0))");

                entity.Property(e => e.ShortDescription)
                    .HasMaxLength(250)
                    .HasColumnName("Short_Description");

                entity.Property(e => e.Title).HasMaxLength(40);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Project__Categor__76619304");

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.ProjectsCreator)
                    .HasForeignKey(d => d.CreatorName)
                    .HasConstraintName("FK__Project__Creator__7755B73D");

                entity.HasMany(d => d.Skills)
                    .WithMany(p => p.Projects)
                    .UsingEntity<Dictionary<string, object>>(
                        "ProjectSkillLink",
                        l => l.HasOne<Skill>().WithMany().HasForeignKey("SkillId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__ProjectSk__Skill__05A3D694"),
                        r => r.HasOne<Project>().WithMany().HasForeignKey("ProjectId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__ProjectSk__Proje__04AFB25B"),
                        j => {
                            j.HasKey("ProjectId", "SkillId").HasName("ProjectSkillLink_Primary_Key");

                            j.ToTable("ProjectSkillLink");

                            j.IndexerProperty<int>("ProjectId").HasColumnName("Project_Id");

                            j.IndexerProperty<int>("SkillId").HasColumnName("Skill_Id");
                        });

                entity.HasMany(d => d.Collaborators)
                    .WithMany(p => p.ProjectsCollaborator)
                    .UsingEntity<Dictionary<string, object>>(
                        "ProjectCollaboratorLink",
                        l => l.HasOne<User>().WithMany().HasForeignKey("Username").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__ProjectCo__Usern__09746778"),
                        r => r.HasOne<Project>().WithMany().HasForeignKey("ProjectId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__ProjectCo__Proje__0880433F"),
                        j => {
                            j.HasKey("ProjectId", "Username").HasName("ProjectCollaboratorLink_Primary_Key");

                            j.ToTable("ProjectCollaboratorLink");

                            j.IndexerProperty<int>("ProjectId").HasColumnName("Project_Id");

                            j.IndexerProperty<string>("Username").HasMaxLength(25);
                        });
            });

            modelBuilder.Entity<Skill>(entity => {
                entity.ToTable("Skill");

                entity.Property(e => e.Name).HasMaxLength(25);
            });

            modelBuilder.Entity<User>(entity => {
                entity.HasKey(e => e.Username)
                    .HasName("PK__User__536C85E55991425E");

                entity.ToTable("User");

                entity.Property(e => e.Username).HasMaxLength(25);

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(300)
                    .HasColumnName("Image_url");

                entity.Property(e => e.Info).HasMaxLength(1000);

                entity.HasMany(d => d.Skills)
                    .WithMany(p => p.Usernames)
                    .UsingEntity<Dictionary<string, object>>(
                        "UserSkillLink",
                        l => l.HasOne<Skill>().WithMany().HasForeignKey("SkillId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__UserSkill__Skill__01D345B0"),
                        r => r.HasOne<User>().WithMany().HasForeignKey("Username").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__UserSkill__Usern__00DF2177"),
                        j => {
                            j.HasKey("Username", "SkillId").HasName("UserSkillLink_Primary_Key");

                            j.ToTable("UserSkillLink");

                            j.IndexerProperty<string>("Username").HasMaxLength(25);

                            j.IndexerProperty<int>("SkillId").HasColumnName("Skill_Id");
                        });
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
