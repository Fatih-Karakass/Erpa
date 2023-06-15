using ErpaHoldingFatihKarakas.Domain.Authentication;
using ErpaHoldingFatihKarakas.Domain.Base;
using ErpaHoldingFatihKarakas.Domain.BasketProducts;
using ErpaHoldingFatihKarakas.Domain.Baskets;
using ErpaHoldingFatihKarakas.Domain.Brands;
using ErpaHoldingFatihKarakas.Domain.Categories;
using ErpaHoldingFatihKarakas.Domain.Models;
using ErpaHoldingFatihKarakas.Domain.Orders;
using ErpaHoldingFatihKarakas.Domain.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpaHoldingFatihKarakas.EntityFrameworkCore
{
    public class ApplicationDbContext:IdentityDbContext<User,Role,Guid>
    {
        public DbSet<Product> Products{ get; set; }
        public DbSet<Basket> Baskets{ get; set; }
        public DbSet<Category> Categories{ get; set; }
        public DbSet<Brand>Brands{ get; set; }
        public DbSet<Model> Models{ get; set; }
        public DbSet<Order> Orders{ get; set; }
        public DbSet<BasketProduct> BasketProducts { get; set; }
        public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>()
                  .HasMany(s => s.Baskets)
                  .WithMany(s => s.Products)
                  .UsingEntity<BasketProduct>
                  (
                sc => sc.HasOne(x => x.Basket).WithMany().HasForeignKey(x => x.BasketId).OnDelete(DeleteBehavior.Cascade),
                sc => sc.HasOne(x => x.Product).WithMany().HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.Cascade),
                sc => sc.HasKey(x => new { x.BasketId, x.ProductId })


                );

            base.OnModelCreating(builder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            Guid? userId = null;

            try
            {
                var httpContextAccessor = this.GetService<IHttpContextAccessor>();
                byte[] userData = null;
                httpContextAccessor.HttpContext?.Session.TryGetValue("UserId", out userData);

                if (userData != null)
                {

                    userId = Guid.Parse(System.Text.Encoding.UTF8.GetString(userData));
                }

            }
            catch (Exception)
            {

                
            }
           
            foreach (var item in ChangeTracker.Entries())
            {
                if(item.Entity is BaseEntity entity)
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            entity.CreateTime = DateTime.Now;
                            entity.CreaterUserId = (Guid)userId!;
                            break;

                        case EntityState.Deleted:
                            entity.DeletionTime = DateTime.Now;
                            entity.DeleterUserId = (Guid)userId!;

                            break;

                        case EntityState.Modified:
                            entity.UpdateTime = DateTime.Now;
                            entity.UpdatetorUserId = (Guid)userId!;

                            break;
                       
                    }
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
