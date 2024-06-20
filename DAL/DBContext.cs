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

        public virtual DbSet<Comment> Comments { get; set; } = null!;

        public virtual DbSet<Request> Requests { get; set; } = null!;

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
                entity.Property(c => c.Price).IsUnicode(false);
                entity.Property(c => c.Locality).HasMaxLength(20);
                entity.Property(c => c.Rating).IsUnicode(false);
                entity.Property(c => c.Capacity).IsUnicode(false);
                entity.Property(c => c.ResponsibleId).IsUnicode(false);
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
                entity.Property(u => u.IsResponsible).IsUnicode(false);
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("Comments");
                entity.HasKey(c => new { c.UserId, c.CampingId });
                entity.Property(u => u.Content).IsUnicode(false);
                entity.Property(u => u.Ratings).IsUnicode(false);
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.ToTable("Requests");
                entity.HasKey(r => new { r.UserId, r.ResponsibleId });
                entity.Property(r => r.CampingId).IsUnicode(false);
                entity.Property(r => r.Status).IsUnicode(false);
                entity.Property(r => r.Start).IsUnicode(false);
                entity.Property(r => r.End).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
