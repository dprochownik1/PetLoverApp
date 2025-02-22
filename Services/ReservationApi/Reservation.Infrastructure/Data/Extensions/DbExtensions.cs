using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.DependencyInjection;

namespace Reservation.Infrastructure.Data.Extensions;

public static class DbExtensions
{
    public static async Task ApplyPendingMigrationsAsync(this WebApplication webApplication)
    {
        using var scope = webApplication.Services.CreateScope();

        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        if (dbContext.Database.GetAppliedMigrationsAsync().GetAwaiter().GetResult().Any())
        {
            await dbContext.Database.MigrateAsync();
        }
    }

    public static bool HasChangedOwnedEntities(this EntityEntry entry) =>
        entry.References.Any(r =>
            r.TargetEntry is not null &&
            r.TargetEntry.Metadata.IsOwned() &&
            r.TargetEntry.State is EntityState.Added or EntityState.Modified);
}