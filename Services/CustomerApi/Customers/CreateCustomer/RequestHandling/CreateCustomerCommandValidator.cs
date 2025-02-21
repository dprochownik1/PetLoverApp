namespace CustomerApi.Customers.CreateCustomer.RequestHandling;

public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
    {
        RuleFor(x => x.Customer).NotNull().WithMessage("Customer must not be null");
        RuleFor(x => x.Customer.CustomerId).NotNull().WithMessage("CustomerId is required");
        RuleFor(x => x.Customer.Name).NotEmpty().MaximumLength(20);
        RuleFor(x => x.Customer.LastName).NotEmpty().MaximumLength(20);
        RuleFor(x => x.Customer.Address).NotNull().WithMessage("Address must not be null");
        RuleFor(x => x.Customer.Address.City).NotEmpty().MaximumLength(20);
        RuleFor(x => x.Customer.Address.Street).NotEmpty().MaximumLength(40);
        RuleFor(x => x.Customer.Address.Building).NotEmpty().MaximumLength(5);
        RuleFor(x => x.Customer.Address.PostalCode).NotEmpty().Length(6);
        RuleFor(x => x.Customer.Address.Flat).MaximumLength(5);
        RuleFor(x => x.Customer.EmailAddress)
            .NotEmpty().EmailAddress().WithMessage("Email address is invalid").MaximumLength(200);
        RuleFor(x => x.Customer.PhoneNumber)
            .NotEmpty().Must(x => x.All(char.IsDigit)).WithMessage("Phone number is invalid").Length(9);
    }
}