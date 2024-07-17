using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.PublishedModels;
using UmbracoBlogPost.Web.AppCode.Models.ViewComponentModels;

namespace UmbracoBlogPost.Web.AppCode.ViewComponents;

[ViewComponent]
public class HeaderViewComponent(
    ILogger<HeaderViewComponent> logger, 
    IUmbracoContextAccessor context)
    : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        HeaderViewVm model = new();

        try
        {
            var content = context?
                .GetRequiredUmbracoContext()?
                .PublishedRequest?
                .PublishedContent;

            if (content is IPageSettings pageSettings)
            {
                model.Title = pageSettings.Title ?? "No Title";
                model.Subtitle = pageSettings.SubTitle ?? "No Subtitle";
                model.BannerImage = pageSettings.BannerImage?.Url() ?? "No Banner Image";

                model.IsBlog = content.IsDocumentType("blog");
                model.Author = content.CreatorName() ?? "";
                model.CreatedDateTime = content.CreateDate;
            }
        }
        catch (Exception e)
        {
            logger.LogError($"Error in HeaderViewComponent: {e.Message}");
        }
        return View(model);
    }
}