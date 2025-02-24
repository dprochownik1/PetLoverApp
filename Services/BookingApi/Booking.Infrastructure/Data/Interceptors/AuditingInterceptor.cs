using Booking.Infrastructure.Data.Extensions;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Booking.Infrastructure.Data.Interceptors;

public class AuditingInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        MarkSavedEntities(eventData.Context);
        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        MarkSavedEntities(eventData.Context);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private static void MarkSavedEntities(DbContext? context)
    {
        if (context == null) return;

        foreach (var entry in context.ChangeTracker.Entries<IEntity>())
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedBy = "admin";
                entry.Entity.CreatedAt = DateTime.UtcNow;
            }

            if (entry.State == EntityState.Added
                || entry.State == EntityState.Modified
                || entry.HasChangedOwnedEntities())
            {
                entry.Entity.LastModifiedBy = "admin";
                entry.Entity.LastModified = DateTime.UtcNow;
            }
        }
    }
}