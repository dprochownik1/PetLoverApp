namespace ProductApi.Products.UpdateProduct.RequestHandling;

public record UpdateProductCommand(Guid Id, string Name, string Category,
    string Description, string ImageFile, decimal Price, TimeSpan Duration)
    : ICommand<UpdateProductResult>;