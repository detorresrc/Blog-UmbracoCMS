namespace UmbracoBlogPost.Web.AppCode.Models.ViewComponentModels;

public class HeaderViewVm
{
    public string Title { get; set; } = string.Empty;
    public string Subtitle { get; set; } = string.Empty;
    public string BannerImage { get; set; } = string.Empty;
    public bool IsBlog { get; set; } = false;
    public string Author { get; set; } = string.Empty;
    public DateTime CreatedDateTime { get; set; }
}