namespace ProductApi.Products.DeleteProduct.RequestHandling;

public record DeleteProductCommand(Guid Id) : ICommand<DeleteProductResult>;