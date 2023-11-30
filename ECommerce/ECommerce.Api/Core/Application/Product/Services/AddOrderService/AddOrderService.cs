using ECommerce.Api.Core.Domain.Entities;
using ECommerce.Api.Core.Interfaces;

namespace ECommerce.Api.Core.Application.Product.Services.AddOrderService;

public class AddOrderService : IAddOrderService
{
    IEcommerceDbContext _dbContext;
    public AddOrderService(IEcommerceDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async void AddOrder(Order order, CancellationToken cancellationToken)
    {

    }
}
