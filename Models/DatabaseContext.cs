using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Models
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Mockery> Mockeries { get; set; }
        public virtual DbSet<MockeryCategory> MockeryCategories { get; set; }
        public virtual DbSet<MockeryTag> MockeryTags { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "en_US.utf8");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("categories");

                entity.HasIndex(e => e.Name, "categories_name_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<Mockery>(entity =>
            {
                entity.ToTable("mockeries");

                entity.HasIndex(e => e.Content, "mockeries_content_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Content).HasColumnName("content");

                entity.Property(e => e.Source).HasColumnName("source");
            });

            modelBuilder.Entity<MockeryCategory>(entity =>
            {
                entity.HasKey(e => new { e.MockeryId, e.CategoryId })
                    .HasName("pk_mockery_categories");

                entity.ToTable("mockery_categories");

                entity.HasIndex(e => e.CategoryId, "ix_mockery_categories_category_id");

                entity.Property(e => e.MockeryId).HasColumnName("mockery_id");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.MockeryCategories)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("fk_mockery_categories_categories_category_id");

                entity.HasOne(d => d.Mockery)
                    .WithMany(p => p.MockeryCategories)
                    .HasForeignKey(d => d.MockeryId)
                    .HasConstraintName("fk_mockery_categories_mockeries_mockery_id");
            });

            modelBuilder.Entity<MockeryTag>(entity =>
            {
                entity.HasKey(e => new { e.MockeryId, e.TagId })
                    .HasName("pk_mockery_tags");

                entity.ToTable("mockery_tags");

                entity.HasIndex(e => e.TagId, "ix_mockery_tags_tag_id");

                entity.Property(e => e.MockeryId).HasColumnName("mockery_id");

                entity.Property(e => e.TagId).HasColumnName("tag_id");

                entity.HasOne(d => d.Mockery)
                    .WithMany(p => p.MockeryTags)
                    .HasForeignKey(d => d.MockeryId)
                    .HasConstraintName("fk_mockery_tags_mockeries_mockery_id");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.MockeryTags)
                    .HasForeignKey(d => d.TagId)
                    .HasConstraintName("fk_mockery_tags_tags_tag_id");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.ToTable("tags");

                entity.HasIndex(e => e.Name, "tags_name_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
