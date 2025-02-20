namespace PetApi.Pets.DeletePetsByCustomer.RequestHandling;

public class DeletePetsByCustomerCommandValidator : AbstractValidator<DeletePetsByCustomerCommand>
{
    public DeletePetsByCustomerCommandValidator()
    {
        RuleFor(x => x.CustomerId).NotEmpty().WithMessage("Customer Id is required");
    }
}