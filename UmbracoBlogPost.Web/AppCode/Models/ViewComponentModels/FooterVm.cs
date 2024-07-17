using Umbraco.Cms.Core.Models.Blocks;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace UmbracoBlogPost.Web.AppCode.Models.ViewComponentModels;

public class FooterVm
{
    public List<FooterLink> FooterLinks { get; set; } = new();
    public BlockListModel? SocialMedia { get; set; }
}

public class FooterLink
{
    public string Name { get; set; }
    public string Link { get; set; }
    public string Target { get; set; }
}

public class FooterSocialMediaLink
{
    public string Link { get; set; }
    public string Icon { get; set; }
    public string Target { get; set; }
}