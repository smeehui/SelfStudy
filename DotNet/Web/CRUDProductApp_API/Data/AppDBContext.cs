using CRUDProductApp_API.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDProductApp_API.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions options) : base(options) { }
        #region DbSet
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(e =>
            {
                e.ToTable("Products");
                e.HasKey(p => p.Id);
                e.Property(p => p.CreatedAt).HasDefaultValueSql("getutcdate()");
                e.Property(p => p.IsDeleted).HasDefaultValue(false);
                e.HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.Category_Id)
                .HasConstraintName("Fk_Cate_Prod")
                .OnDelete(DeleteBehavior.SetNull);
            });
            modelBuilder.Entity<Category>(e =>
            {
                e.ToTable("Categories");
                e.Property(c => c.IsDeleted).HasDefaultValue(false);
                e.HasKey(c => c.Id);

            });
        }


    }
}
