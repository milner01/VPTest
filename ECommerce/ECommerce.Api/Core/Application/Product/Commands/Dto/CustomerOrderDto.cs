namespace ECommerce.Api.Core.Application.Product.Commands.Dto;

public record CustomerOrderDto(int OrderId, List<ProductDto>? Products);
