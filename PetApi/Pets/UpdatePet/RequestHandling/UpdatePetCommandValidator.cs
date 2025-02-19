namespace PetApi.Pets.UpdatePet.RequestHandling;

public class UpdatePetCommandValidator : AbstractValidator<UpdatePetCommand>
{
    public UpdatePetCommandValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty().WithMessage("Pet Id is required");
        RuleFor(command => command.Species)
            .MaximumLength(40).WithMessage("Species must not be longer than 40 characters");
        RuleFor(command => command.Race)
            .MaximumLength(20).WithMessage("Race must not be longer than 20 characters");
        RuleFor(command => command.Name)
            .MaximumLength(20).WithMessage("Name must not be longer than 20 characters");
        RuleFor(x => x.ImageUrl)
            .MaximumLength(500).WithMessage("ImageUrl must not be longer than 500 characters");
    }
}