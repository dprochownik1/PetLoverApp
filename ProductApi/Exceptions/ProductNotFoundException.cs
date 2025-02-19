using Common.Lib.Exceptions;

namespace ProductApi.Exceptions;

public class ProductNotFoundException : NotFoundException
{
    public ProductNotFoundException(Guid id) : base("Product", id)
    {
    }
}