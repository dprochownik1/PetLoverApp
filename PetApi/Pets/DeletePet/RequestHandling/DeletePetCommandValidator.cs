namespace PetApi.Pets.DeletePet.RequestHandling;

public class DeletePetCommandValidator : AbstractValidator<DeletePetCommand>
{
    public DeletePetCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Pet Id is required");
    }
}