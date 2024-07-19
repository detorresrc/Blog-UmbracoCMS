using Microsoft.AspNetCore.DataProtection;
using Umbraco.Cms.Core.Sections;

namespace UmbracoBlogPost.Web.App_Plugins.ContactUs;

public class ContactUsSection : ISection
{
    public string Alias => "contactUsSection";
    public string Name => "Contact Us";
}