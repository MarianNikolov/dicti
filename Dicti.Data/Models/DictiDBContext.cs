using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Dicti.Data.Models
{
    public partial class DictiDBContext : DbContext
    {
        public DictiDBContext()
        {
        }

        public DictiDBContext(DbContextOptions<DictiDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Languages> Languages { get; set; }
        public virtual DbSet<TransalationValues> TransalationValues { get; set; }
        public virtual DbSet<Translations> Translations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:dictiserver.database.windows.net,1433;Initial Catalog=DictiDB;Persist Security Info=False;User ID=dictiserver;Password=azureTest1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Languages>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Language)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TransalationValues>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.TransalationValues)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TransalationValues_Languages");

                entity.HasOne(d => d.Transaltion)
                    .WithMany(p => p.TransalationValues)
                    .HasForeignKey(d => d.TransaltionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TransalationValues_Translations");
            });

            modelBuilder.Entity<Translations>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DeletedOn).HasColumnType("datetime");

                entity.Property(e => e.EditedOn).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
