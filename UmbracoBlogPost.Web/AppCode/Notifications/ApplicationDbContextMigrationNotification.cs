using Microsoft.EntityFrameworkCore;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Notifications;
using UmbracoBlogPost.Web.AppCode.CustomDbContext;

namespace UmbracoBlogPost.Web.AppCode.Notifications;

public class ApplicationDbContextMigrationNotification(ApplicationDbContext dbContext, ILogger<ApplicationDbContextMigrationNotification> logger) : INotificationAsyncHandler<UmbracoApplicationStartedNotification>
{
    public async Task HandleAsync(UmbracoApplicationStartedNotification notification, CancellationToken cancellationToken)
    {
        IEnumerable<string> pendingMigrations = await dbContext.Database.GetPendingMigrationsAsync(cancellationToken);
        if (pendingMigrations.Any())
            await dbContext.Database.MigrateAsync(cancellationToken);
        else
            logger.LogInformation($"No pending migrations found.");
    }
}