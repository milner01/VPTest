namespace ECommerce.Api.Core.Application.Product.Commands.Dto;

public record ProductDto(
    int ProductId,
    string ProductName,
    int Quantity,
    decimal UnitPrice);
