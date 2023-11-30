using ECommerce.Api.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Api.Core.Interfaces;

public interface IEcommerceDbContext : IDisposable
{
    DbSet<Order> Order { get; set; }
    DbSet<Product> Products { get; }

    int SaveChanges();
}

public class CoreDbContext : DbContext, IEcommerceDbContext
{
    public virtual DbSet<Order> Order { get; set; }
    public virtual DbSet<Product> Products { get; }

}
