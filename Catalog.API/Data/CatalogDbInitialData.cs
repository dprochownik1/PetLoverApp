using Marten.Schema;

namespace Catalog.API.Data;

public class CatalogDbInitialData : IInitialData
{
    public async Task Populate(IDocumentStore store, CancellationToken cancellationToken)
    {
        await using var session = store.LightweightSession();

        if (await session.Query<Product>().AnyAsync(cancellationToken))
            return;

        //This is UPSERT operation
        session.Store(GetInitialProducts());
        await session.SaveChangesAsync(cancellationToken);
    }

    public static IEnumerable<Product> GetInitialProducts() => new List<Product>
    {
        new()
        {
            Id = Guid.NewGuid(),
            Name = "Dog Grooming Package",
            Description = "Complete grooming service for dogs, including bath, haircut, and nail trimming.",
            Category = Category.PetGrooming.ToString(),
            ImageFile = "dog_grooming.png",
            Price = 80.00m,
            Duration = TimeSpan.FromHours(2)
        },
        new()
        {
            Id = Guid.NewGuid(),
            Name = "Cat Veterinary Checkup",
            Description = "Regular health checkup for your cat, including vaccinations and general health assessment.",
            Category = Category.VeterinaryCare.ToString(),
            ImageFile = "cat_vet_checkup.png",
            Price = 120.00m,
            Duration = TimeSpan.FromHours(1)
        },
        new()
        {
            Id = Guid.NewGuid(),
            Name = "Premium Pet Food Delivery",
            Description = "Monthly subscription for premium pet food delivered to your door.",
            Category = Category.PetFoodDelivery.ToString(),
            ImageFile = "pet_food_delivery.png",
            Price = 50.00m,
            Duration = TimeSpan.FromDays(30)
        },
        new()
        {
            Id = Guid.NewGuid(),
            Name = "Dog Walking Service",
            Description = "Daily dog walking service by a professional pet walker.",
            Category = Category.PetWalking.ToString(),
            ImageFile = "dog_walking.png",
            Price = 20.00m,
            Duration = TimeSpan.FromHours(1)
        },
        new()
        {
            Id = Guid.NewGuid(),
            Name = "Pet Boarding (Weekend)",
            Description = "Safe and comfortable boarding for pets during the weekend.",
            Category = Category.PetBoarding.ToString(),
            ImageFile = "pet_boarding.png",
            Price = 150.00m,
            Duration = TimeSpan.FromDays(2)
        },
        new()
        {
            Id = Guid.NewGuid(),
            Name = "Dog Training - Basic Obedience",
            Description = "Teach your dog basic commands and good behavior.",
            Category = Category.PetTraining.ToString(),
            ImageFile = "dog_training.png",
            Price = 100.00m,
            Duration = TimeSpan.FromHours(3)
        },
        new()
        {
            Id = Guid.NewGuid(),
            Name = "Pet Sitting (Full Day)",
            Description = "Full day pet sitting at your home by a trusted sitter.",
            Category = Category.PetSitting.ToString(),
            ImageFile = "pet_sitting.png",
            Price = 60.00m,
            Duration = TimeSpan.FromHours(8)
        },
        new()
        {
            Id = Guid.NewGuid(),
            Name = "Pet Taxi Service",
            Description = "Safe transportation for pets to vet appointments or grooming sessions.",
            Category = Category.PetTransport.ToString(),
            ImageFile = "pet_taxi.png",
            Price = 30.00m,
            Duration = TimeSpan.FromHours(1)
        },
        new()
        {
            Id = Guid.NewGuid(),
            Name = "Pet Photography Session",
            Description = "Capture beautiful moments of your pet with a professional photoshoot.",
            Category = Category.PetPhotography.ToString(),
            ImageFile = "pet_photography.png",
            Price = 200.00m,
            Duration = TimeSpan.FromHours(2)
        },
        new()
        {
            Id = Guid.NewGuid(),
            Name = "Pet Adoption Consultation",
            Description = "Guidance and support in choosing the right pet for adoption.",
            Category = Category.PetAdoption.ToString(),
            ImageFile = "pet_adoption.png",
            Price = 0.00m,
            Duration = TimeSpan.FromHours(1)
        },
        new()
        {
            Id = Guid.NewGuid(),
            Name = "Pet Wellness Checkup",
            Description = "Comprehensive wellness checkup for your pet, including diet and exercise advice.",
            Category = Category.PetWellness.ToString(),
            ImageFile = "pet_wellness.png",
            Price = 90.00m,
            Duration = TimeSpan.FromHours(1.5)
        },
        new()
        {
            Id = Guid.NewGuid(),
            Name = "Luxury Pet Boarding",
            Description = "Luxury boarding services for pets with personalized care and attention.",
            Category = Category.PetBoarding.ToString(),
            ImageFile = "luxury_pet_boarding.png",
            Price = 250.00m,
            Duration = TimeSpan.FromDays(3)
        },
        new()
        {
            Id = Guid.NewGuid(),
            Name = "Puppy Socialization Class",
            Description = "Help your puppy learn social skills and proper behavior in a fun environment.",
            Category = Category.PetTraining.ToString(),
            ImageFile = "puppy_socialization.png",
            Price = 70.00m,
            Duration = TimeSpan.FromHours(2)
        },
        new()
        {
            Id = Guid.NewGuid(),
            Name = "Pet Supplies Starter Kit",
            Description = "A complete starter kit of pet supplies for new pet owners.",
            Category = Category.PetSupplies.ToString(),
            ImageFile = "pet_supplies_kit.png",
            Price = 100.00m,
            Duration = TimeSpan.Zero
        },
        new()
        {
            Id = Guid.NewGuid(),
            Name = "Mobile Veterinary Service",
            Description = "Veterinary care at your home for pets that experience stress during travel.",
            Category = Category.VeterinaryCare.ToString(),
            ImageFile = "mobile_vet_service.png",
            Price = 150.00m,
            Duration = TimeSpan.FromHours(2)
        }
    };
}