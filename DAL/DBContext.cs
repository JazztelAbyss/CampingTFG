using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public partial class DBContext : DbContext
    {
        public DBContext() { }
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }

        public virtual DbSet<Camping> Campings { get; set; } = null!;

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
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
