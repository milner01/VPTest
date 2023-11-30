namespace ECommerce.Api.Core.Domain.Entities;

public class Order
{
    public Order(string? customerName, string shippingAddress, List<Product>? products, decimal? totalPrice, DateTime? orderDate)
    {
        CustomerName = customerName ?? throw new ArgumentNullException("Error: Customer Name cannot be empty."); // Discussion: Basic Validation
        ShippingAddress = shippingAddress ?? throw new ArgumentNullException("Error: Shipping Address cannot be empty.");
        Products = products ?? throw new ArgumentNullException("Error: Products cannot be empty.");
        TotalPrice = totalPrice ?? throw new ArgumentNullException("Error: Total Price cannot be empty.");
        OrderDate = orderDate ?? throw new ArgumentNullException("Error: Order Date Price cannot be empty.");
    }

    public int Id { get; set; }
    public string? CustomerName { get; private set; }
    public string? ShippingAddress { get; private set; }
    public List<Product>? Products { get; private set; }
    public decimal? TotalPrice { get; private set; }
    public DateTime? OrderDate { get; private set; }
}
