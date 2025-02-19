namespace CartApi.Models;

public class Cart
{
    public Guid CustomerId { get; set; }
    public IEnumerable<CartItem> Items { get; set; } = default!;
}
