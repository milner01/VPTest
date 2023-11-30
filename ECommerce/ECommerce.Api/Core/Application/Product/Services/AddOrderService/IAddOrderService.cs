using ECommerce.Api.Core.Domain.Entities;

namespace ECommerce.Api.Core.Application.Product.Services.AddOrderService;

public interface IAddOrderService
{
    void AddOrder(Order order, CancellationToken cancellationToken);
}
