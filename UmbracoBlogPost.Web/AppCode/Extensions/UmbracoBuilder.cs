using Umbraco.Cms.Core.Notifications;
using UmbracoBlogPost.Web.AppCode.Notifications;

namespace UmbracoBlogPost.Web.AppCode.Extensions;

public static partial class UmbracoBuilder
{
    public static IUmbracoBuilder AddCustomNotificationServices(this IUmbracoBuilder builder)
    {
        builder
            .AddNotificationAsyncHandler<UmbracoApplicationStartedNotification, ApplicationDbContextMigrationNotification>();

        return builder;
    }
}