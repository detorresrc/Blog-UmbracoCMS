using Umbraco.Cms.Core.Composing;
using UmbracoBlogPost.Web.App_Plugins.ContactUs;

namespace UmbracoBlogPost.Web.App_Plugins;

public class SectionComposer : IComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
        builder.Sections().Append<ContactUsSection>();
    }
}