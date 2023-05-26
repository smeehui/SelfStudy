using Microsoft.EntityFrameworkCore;
using ProuctCRUD_RepoPattern.Model;

namespace ProductCRUD_RepoPattern.DB
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions options) : base(options) { }
        #region
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(e =>
            {
                e.ToTable("Products");
                e.HasKey(p => p.Id);
                e.Property(p => p.CreatedAt).HasDefaultValue(DateTime.Now);
                e.Property(p => p.IsDeleted).HasDefaultValue(false);
                e.HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasConstraintName("fk_prod_cate")
                .OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<Category>(e =>
            {
                e.ToTable("Categories");
                e.HasKey(p => p.Id);
                e.Property(p => p.CreatedAt).HasDefaultValue(DateTime.Now);
                e.Property(p => p.IsDeleted).HasDefaultValue(false);
            });
        }

    }
}
