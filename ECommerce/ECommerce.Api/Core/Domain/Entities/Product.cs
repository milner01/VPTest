namespace ECommerce.Api.Core.Domain.Entities;

public class Product
{
    public Product(string productName, int quantity, decimal sellPrice)
    {
        ProductName = productName;
        Quantity = quantity;
        SellPrice = sellPrice;
    }

    public int Id { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public decimal SellPrice { get; set; }
}
