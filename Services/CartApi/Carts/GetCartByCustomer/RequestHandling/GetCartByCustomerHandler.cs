namespace CartApi.Carts.GetCartByCustomer.RequestHandling;

public class GetCartHandler(ICartRepository repository) : IQueryHandler<GetCartByCustomerQuery, GetCartByCustomerResult>
{
    public async Task<GetCartByCustomerResult> Handle(GetCartByCustomerQuery byCustomerQuery, CancellationToken cancellationToken)
    {
        var cartDto = await repository.GetCart(byCustomerQuery.CustomerId, cancellationToken);

        return new GetCartByCustomerResult(cartDto);
    }
}
