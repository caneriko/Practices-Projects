using Microsoft.EntityFrameworkCore;
using MyMvcApp.Core.Entities;
using System.Reflection;

namespace MyMvcApp.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<ProductFeature>().HasData(
                new ProductFeature() { Id = 1, Color = "Kırmızı", Height = 10, Width = 2, ProductId = 1 },
                new ProductFeature() { Id = 2, Color = "Siyah", Height = 12, Width = 2, ProductId = 2 },
                new ProductFeature() { Id = 3, Color = "Beyaz", Height = 20, Width = 8, ProductId = 3 },
                new ProductFeature() { Id = 4, Color = "Turuncu", Height = 25, Width = 10, ProductId = 4 }
                );

            base.OnModelCreating(modelBuilder);
        }


        public override int SaveChanges()
        {
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is BaseEntity entityReference)
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            {
                                entityReference.CreatedDate = DateTime.Now;
                                break;
                            }

                        case EntityState.Modified:
                            {
                                Entry(entityReference).Property(x => x.CreatedDate).IsModified = false;
                                entityReference.UpdatedDate = DateTime.Now;
                                break;
                            }
                    }
                }
            }

            return base.SaveChanges();
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is BaseEntity entityReference)
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            {
                                entityReference.CreatedDate=DateTime.Now;
                                break;
                            }

                            case EntityState.Modified:
                            {
                                Entry(entityReference).Property(x => x.CreatedDate).IsModified = false;
                                entityReference.UpdatedDate=DateTime.Now;
                                break;
                            }
                    }
                }
            }



            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
