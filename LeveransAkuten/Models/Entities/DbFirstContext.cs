using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LeveransAkuten.Models.Entities
{
    public partial class DbFirstContext : DbContext
    {
        public DbFirstContext()
        {
        }

        public DbFirstContext(DbContextOptions<DbFirstContext> options)
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
                entity.Property(e => e.Arequired).HasColumnName("ARequired");

                entity.Property(e => e.Brequired).HasColumnName("BRequired");

                entity.Property(e => e.Cerequired).HasColumnName("CERequired");

                entity.Property(e => e.Crequired).HasColumnName("CRequired");

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.Drequired).HasColumnName("DRequired");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Header)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Ad)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Ad__CompanyId__75A278F5");

                entity.HasOne(d => d.Driver)
                    .WithMany(p => p.Ad)
                    .HasForeignKey(d => d.DriverId)
                    .HasConstraintName("FK__Ad__DriverId__74AE54BC");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.Property(e => e.AspNetUsersId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(500);
            });

            modelBuilder.Entity<Driver>(entity =>
            {
                entity.Property(e => e.AspNetUsersId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
