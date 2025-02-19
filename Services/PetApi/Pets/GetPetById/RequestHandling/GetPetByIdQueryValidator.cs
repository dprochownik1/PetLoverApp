namespace PetApi.Pets.GetPetById.RequestHandling;

public class GetPetByIdQueryValidator : AbstractValidator<GetPetByIdQuery>
{
    public GetPetByIdQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Pet Id is required");
    }
}