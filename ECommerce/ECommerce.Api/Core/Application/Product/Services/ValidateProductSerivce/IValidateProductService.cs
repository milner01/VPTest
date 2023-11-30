namespace ECommerce.Api.Core.Application.Product.Services.ValidateProductSerivce;

public interface IValidateProductService
{
    public bool ValidateProductSellPrice(List<Domain.Entities.Product> products);
}
