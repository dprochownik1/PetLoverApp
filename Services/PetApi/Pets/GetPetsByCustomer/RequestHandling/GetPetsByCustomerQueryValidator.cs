namespace PetApi.Pets.GetPetsByCustomer.RequestHandling;

public class GetPetsByCustomerQueryValidator : AbstractValidator<GetPetsByCustomerQuery>
{
    public GetPetsByCustomerQueryValidator()
    {
        RuleFor(x => x.CustomerId)
            .NotEmpty().WithMessage("CustomerId is required");
    }
}