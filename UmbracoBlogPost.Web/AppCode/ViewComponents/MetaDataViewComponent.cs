using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.PublishedModels;
using UmbracoBlogPost.Web.AppCode.Models.ViewComponentModels;

namespace UmbracoBlogPost.Web.AppCode.ViewComponents;

[ViewComponent]
public class MetaDataViewComponent(
    ILogger<MetaDataViewComponent> logger,
    IUserService userService,
    IUmbracoContextAccessor context) : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        MetaDataVm model = new();
        
        try
        {
            var content = context?
                .GetRequiredUmbracoContext()?
                .PublishedRequest?
                .PublishedContent;
            if (content is null) throw new Exception("Content is null");

            var author = userService.GetUserById(content.CreatorId);
            if (author is not null)
                model.Author = author.Name ?? "";

            if (content is IPageSettings pageSettings)
            {
                model.Title = pageSettings.MetaTitle ?? "";
                model.Description = pageSettings.Description ?? "";
            }
        }
        catch (Exception e)
        {
            logger.LogError($"Error in HeaderViewComponent: {e.Message}");
        }

        return View(model);
    }
}