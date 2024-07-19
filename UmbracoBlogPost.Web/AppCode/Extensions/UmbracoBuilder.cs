using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Umbraco.Cms.Core.Mapping;
using Umbraco.Cms.Core.Notifications;
using UmbracoBlogPost.Web.AppCode.Config.MappingProfile;
using UmbracoBlogPost.Web.AppCode.Notifications;

namespace UmbracoBlogPost.Web.AppCode.Extensions;

public static partial class UmbracoBuilder
{
    public static IUmbracoBuilder AddCustomNotificationServices(this IUmbracoBuilder builder)
    {
        builder
            .AddNotificationAsyncHandler<UmbracoApplicationStartedNotification, ApplicationDbContextMigrationNotification>();

        builder.WithCollectionBuilder<MapDefinitionCollectionBuilder>()
            .Add<ContactUsMappingProfile>();

        builder.Services.ConfigureOptions<ConfigureSwaggerGenOptions>();
        
        return builder;
    }
}

public class ConfigureSwaggerGenOptions : IConfigureOptions<SwaggerGenOptions>
{
    public void Configure(SwaggerGenOptions options)
    {
        options.SwaggerDoc(
            "v1.0",
            new OpenApiInfo
            {
                Title = "API v1",
                Version = "1.0",
            });
    }
}
