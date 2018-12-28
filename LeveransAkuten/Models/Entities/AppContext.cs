using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using LeveransAkuten.Models.ViewModels.Ads;

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
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BudAkuten;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Ad>(entity =>
            {
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

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Ad)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Ad__UserId__4E88ABD4");
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.City).HasMaxLength(100);

                entity.Property(e => e.Description).HasMaxLength(2000);

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.ImageUrl).HasMaxLength(250);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.StreetAdress).HasMaxLength(100);

                entity.Property(e => e.UserName).HasMaxLength(256);

              
            });
        }

        public DbSet<LeveransAkuten.Models.ViewModels.Ads.AdsVm> AdsVm { get; set; }
    }
}
