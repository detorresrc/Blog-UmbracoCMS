using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Web.Common;
using Umbraco.Cms.Web.Common.PublishedModels;
using UmbracoBlogPost.Web.AppCode.Models;

namespace UmbracoBlogPost.Web.AppCode.ViewComponents;

[ViewComponent]
public class BlogsViewComponent(
    ILogger<FooterViewComponent> logger,
    UmbracoHelper helper) : ViewComponent
{
    
    public IViewComponentResult Invoke(int page=0, int pageSize = 1)
    {
        PaginatedList<Blog>? model = null;
        try
        {
            IQueryable<Blog> query = helper.ContentAtRoot()
                .DescendantsOrSelf<Blog>()
                .Where(x => x.IsVisible())
                .OrderByDescending(x => x.CreateDate)
                .AsQueryable();

            model = PaginatedList<Blog>.Create(query, page, pageSize);
        }
        catch (Exception e)
        {
            logger.LogError($"Error in BlogsViewComponent: {e.Message}");
        }

        return View(model);
    }
    
}