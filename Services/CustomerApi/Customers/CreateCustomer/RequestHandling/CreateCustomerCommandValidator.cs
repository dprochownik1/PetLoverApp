namespace CustomerApi.Customers.CreateCustomer.RequestHandling;

public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
    {
        RuleFor(x => x.CustomerDto).NotEmpty().WithMessage("CustomerDto must not be null");
        RuleFor(x => x.CustomerDto.UserId).NotEmpty().WithMessage("UserId is required");
        RuleFor(x => x.CustomerDto.Name).NotEmpty().MaximumLength(20);
        RuleFor(x => x.CustomerDto.LastName).NotEmpty().MaximumLength(20);
        RuleFor(x => x.CustomerDto.Address).NotEmpty().WithMessage("Address must not be null");
        RuleFor(x => x.CustomerDto.Address.City).NotEmpty().MaximumLength(20);
        RuleFor(x => x.CustomerDto.Address.Street).NotEmpty().MaximumLength(40);
        RuleFor(x => x.CustomerDto.Address.Building).NotEmpty().MaximumLength(5);
        RuleFor(x => x.CustomerDto.Address.PostalCode).NotEmpty().Length(6);
        RuleFor(x => x.CustomerDto.Address.Flat).MaximumLength(5);
        RuleFor(x => x.CustomerDto.EmailAddress)
            .NotEmpty().EmailAddress().WithMessage("Email address is invalid").MaximumLength(50);
        RuleFor(x => x.CustomerDto.PhoneNumber)
            .NotEmpty().Must(x => x.All(char.IsDigit)).WithMessage("Phone number is invalid").Length(9);
    }
}