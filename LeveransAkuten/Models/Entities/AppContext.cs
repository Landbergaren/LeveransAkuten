using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LeveransAkuten.Models.Entities
{
    public partial class AppContext : DbContext
    {
        public AppContext()
        {
        }

        public AppContext(DbContextOptions<AppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ad> Ad { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Driver> Driver { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BudAkuten;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Ad>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Arequired)
                    .HasColumnName("ARequired")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Brequired)
                    .HasColumnName("BRequired")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Cerequired)
                    .HasColumnName("CERequired")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Crequired)
                    .HasColumnName("CRequired")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.Drequired)
                    .HasColumnName("DRequired")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Header).HasMaxLength(50);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Ad)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Ad__CompanyId__693CA210");
            });

            
            modelBuilder.Entity<Company>(entity =>
            {
                entity.Property(e => e.AccountId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.ImageUrl).HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StreetAdress)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ZipCode)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Driver>(entity =>
            {
                entity.Property(e => e.A).HasDefaultValueSql("((0))");

                entity.Property(e => e.AccountId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.B).HasDefaultValueSql("((0))");

                entity.Property(e => e.C).HasDefaultValueSql("((0))");

                entity.Property(e => e.Ce)
                    .HasColumnName("CE")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.D).HasDefaultValueSql("((0))");

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ImageUrl).HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StreetAdress)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ZipCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Driver)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Driver__AccountI__4BAC3F29");
            });
        }
    }
}
