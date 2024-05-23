using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public partial class DBContext : DbContext
    {
        public DBContext() { }
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }

        public virtual DbSet<Camping> Campings { get; set; } = null!;

        public virtual DbSet<Service> Services { get; set; } = null!;

        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Camping>(entity =>
            {
                entity.ToTable("Campings");
                entity.Property(c => c.Id).HasColumnName("Id");
                entity.Property(c => c.Name).HasMaxLength(20);
                entity.Property(c => c.Description).HasMaxLength(100);
                entity.Property(c => c.Portrait).IsUnicode(false);
                entity.Property(c => c.CoordX).IsUnicode(false);
                entity.Property(c => c.CoordY).IsUnicode(false);
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("Services");
                entity.Property(s => s.Id).HasColumnName("Id");
                entity.Property(s => s.Icon).IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");
                entity.Property(u => u.Id).HasColumnName("Id");
                entity.Property(u => u.Name).HasMaxLength(20);
                entity.Property(u => u.Mail).HasMaxLength(30);
                entity.Property(u => u.Password).HasMaxLength(30);
                entity.Property(u => u.Pic).IsUnicode(false);
                entity.Property(u => u.IsResponsible).HasDefaultValue(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
