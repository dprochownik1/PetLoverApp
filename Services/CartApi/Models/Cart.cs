namespace CartApi.Models;

public class Cart
{
    public Guid CustomerId { get; set; }
    public ICollection<CartItem> Items { get; set; } = default!;
}
