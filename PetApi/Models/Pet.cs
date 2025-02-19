namespace PetApi.Models;

public class Pet
{
    public Guid Id { get; init; }
    public Guid CustomerId { get; init; }
    public string Species { get; set; } = default!;
    public string Race { get; set; } = default!;
    public string Name { get; set; } = default!;
    public DateTime DateOfBirth { get; set; }
    public string ImageUrl { get; set; } = default!;
}