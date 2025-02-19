namespace CartApi.Carts.GetCartByCustomer.RequestHandling;

public record GetCartByCustomerQuery(Guid CustomerId) : IQuery<GetCartByCustomerResult>;