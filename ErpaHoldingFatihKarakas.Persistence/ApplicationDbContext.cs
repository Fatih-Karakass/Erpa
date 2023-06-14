using ErpaHoldingFatihKarakas.Domain.Authentication;
using ErpaHoldingFatihKarakas.Domain.Base;
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
      

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
      
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var httpContextAccessor = this.GetService<IHttpContextAccessor>();
            byte[] userData = null;
            Guid? userId = null;
            httpContextAccessor.HttpContext?.Session.TryGetValue("UserId", out userData);

            if (userData != null)
            {

                userId = Guid.Parse(System.Text.Encoding.UTF8.GetString(userData));
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
