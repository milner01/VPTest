using ECommerce.Api.Core.Interfaces;

namespace ECommerce.Api.Core.Application.Product.Services.ValidateProductSerivce;

public class ValidateProductService : IValidateProductService
{
    private readonly IEcommerceDbContext _dbContext;
    public ValidateProductService(IEcommerceDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public bool ValidateProductSellPrice(List<Domain.Entities.Product> products)
    {
        var productIds = products?.Select(p => p.Id).ToList();

        var databaseProducts = _dbContext.Products.Where(p => productIds.Contains(p.Id));

        foreach (var product in products)
        {
            var correspondingDatabaseProduct = databaseProducts
                .FirstOrDefault(p => p.Id == product.Id);

            if (correspondingDatabaseProduct != null)
            {
                if (product.SellPrice != correspondingDatabaseProduct.SellPrice)
                {
                    return false;
                }
            }
        }

        return true;
    }
}
