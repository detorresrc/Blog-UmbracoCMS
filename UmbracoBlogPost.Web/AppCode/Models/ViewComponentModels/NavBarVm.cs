namespace UmbracoBlogPost.Web.AppCode.Models.ViewComponentModels;

public class NavBarVm
{
    public string? SiteName { get; set; }
    public string? LogoUrl { get; set; }
    public List<NavBarChild> NavBarChildren { get; set; } = new();
}

public class NavBarChild
{
    public string? Name { get; set; }
    public string? Url { get; set; }
}