namespace CartApi.Models;

public class CartItem
{
    public Guid ProductId { get; set; } = default!;
    public string ProductName { get; set; } = default!;
    public decimal ProductPrice { get; set; } = default!;
    public TimeSpan ProductDuration { get; set; }
}
