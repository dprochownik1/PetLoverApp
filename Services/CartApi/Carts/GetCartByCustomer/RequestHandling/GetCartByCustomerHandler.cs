using CartApi.Carts.GetCartByCustomer.Data.Repository;

namespace CartApi.Carts.GetCartByCustomer.RequestHandling;

public class GetCartHandler(IGetCartRepository repository) : IQueryHandler<GetCartByCustomerQuery, GetCartByCustomerResult>
{
    public async Task<GetCartByCustomerResult> Handle(GetCartByCustomerQuery byCustomerQuery, CancellationToken cancellationToken)
    {
        var cartDto = await repository.GetCart(byCustomerQuery.CustomerId, cancellationToken);

        return new GetCartByCustomerResult(cartDto);
    }
}
