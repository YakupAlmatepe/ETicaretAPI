using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Product = ETicaretAPI.Domain.Entities.Product;

namespace ETicaretAPI.Persistence.Contexts
{
    public class EticaretAPIDbContext : DbContext
    { 
        public EticaretAPIDbContext(DbContextOptions options) : base(options)
        { 

        }
        //veri tabanına P.O.C entityleri ile alakalı tabloları oluşturma
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker
                 .Entries<BaseEntity>();
            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate =DateTime.UtcNow,//veri savechange tetiklendiğinde yakalanan dataları yakalayarak sql sorgularını oluşturacağız
                    EntityState.Modified =>data.Entity.UpdatedDate = DateTime.UtcNow,
                };
            }
            return await base.SaveChangesAsync(cancellationToken);
        }

    }
}
