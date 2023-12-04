using ECommerce.Api.Core.Application.Product.Commands.Dto;
using ECommerce.Api.Core.Application.Product.Commands.ViewModels;
using ECommerce.Api.Core.Application.Product.Services.ValidateProductSerivce;
using ECommerce.Api.Core.Domain.Entities;
using ECommerce.Api.Core.Interfaces;
using MediatR;

namespace ECommerce.Api.Core.Application.Product.Commands;

public class CreateOrderCommand : IRequest<CustomerOrderVm>
{
    // Discussion: Basic Validation
    public string CustomerName
    {
        get
        {
            if (string.IsNullOrWhiteSpace(this.CustomerName))
            {
                throw new ArgumentNullException("Error: Customer Name cannot be empty");
            }
            return this.CustomerName;
        }
        set { }
    }

    public string ShippingAddress
    {
        get
        {
            if (string.IsNullOrWhiteSpace(this.ShippingAddress))
            {
                throw new ArgumentNullException("Error: Shipping Address cannot be empty");
            }
            return this.ShippingAddress;
        }
        set { }
    }

    public List<Domain.Entities.Product> Products
    {
        get
        {
            if (this.Products == null)
            {
                throw new ArgumentNullException("Error: Products cannot be empty");
            }
            return this.Products;
        }
        set { }
    }

    public decimal? TotalPrice
    {
        get
        {
            if (this.TotalPrice == 0 || this.TotalPrice == null)
            {
                throw new Exception("Error: Total price cannot be 0 or empty");
            }
            return this.TotalPrice;
        }
        set { }
    }
    public DateTime? OrderDate
    {
        get
        {
            if (this.OrderDate == null)
            {
                throw new Exception("Error: Order date cannot be 0 or empty");
            }
            return this.OrderDate;
        }
        set { }
    }
}

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CustomerOrderVm>
{
    private readonly IEcommerceDbContext _dbContext;
    private readonly IValidateProductService _validateProductService;

    public CreateOrderCommandHandler(IEcommerceDbContext dbContext, IValidateProductService validateProductService)
    {
        _dbContext = dbContext;
        _validateProductService = validateProductService;
    }

    public async Task<CustomerOrderVm> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var isProductListValid = _validateProductService.ValidateProductSellPrice(request.Products);

        if (!isProductListValid)
        {
            throw new Exception("Error: Product not found");
        }

        var order = new Order(request.CustomerName, request.ShippingAddress, request.Products, request.TotalPrice, request.OrderDate);

        await _dbContext.Order.AddAsync(order, cancellationToken);
        _dbContext.SaveChanges();

        #region Discussion
        // I wouldn't normally do this here... The task asked for the order to return a link to the customer which includes their order and
        // the products they've ordered. What I'd normally do is within the front end, chain my api calls to do a post to save the data, followed by a 
        // get to retrieve the data, based on the new Id created, so my normal return for a post like this would be to simply return order.Id, then use that 
        // id in my front end to then get the customer/product information to display to the user, thus further making my endpoints modular and only having one 
        // responsiblity, as it stands now it has 2 responsibilities, it's responsible for saving the order to the database and returning that order for the 
        // customer to view. 
        #endregion

        var productsDto = request.Products.Select(p => new ProductDto(p.Id, p.ProductName, p.Quantity, p.SellPrice));
        return new CustomerOrderVm(new CustomerOrderDto(order.Id, productsDto?.ToList()));

    }
}
