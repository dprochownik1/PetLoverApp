using Common.Lib.Exceptions;

namespace PetApi.Exceptions;

public class PetNotFoundException : NotFoundException
{
    public PetNotFoundException(Guid id) : base("Pet", id)
    {
    }
}