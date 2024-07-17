using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Web.Common;
using Umbraco.Cms.Web.Common.PublishedModels;
using UmbracoBlogPost.Web.AppCode.Models.ViewComponentModels;

namespace UmbracoBlogPost.Web.AppCode.ViewComponents;

[ViewComponent]
public class NavBarViewComponent(
    ILogger<NavBarViewComponent> logger,
    UmbracoHelper helper) : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        NavBarVm model = new();
        try
        {
            var homePage = helper.ContentAtRoot().FirstOrDefault(x => x.IsDocumentType("home") && x.IsVisible()) as Home;

            if (homePage is null) return View();

            model.SiteName = homePage.SiteName;
            model.LogoUrl = homePage?.Logo?.Url() ?? "";
            model.NavBarChildren.Add(new()
            {
                Name = homePage.Name,
                Url = homePage.Url()
            });
            
            foreach (var item in homePage.Children())
            {
                if (!item.IsVisible()) continue;
                if(item is IPageSettings pageSettings && pageSettings.DisplayOnNavbar == false) continue;
                
                model.NavBarChildren.Add(new()
                {
                    Name = item.Name,
                    Url = item.Url()
                });
            }
        }
        catch (Exception e)
        {
            logger.LogError($"Error in HeaderViewComponent: {e.Message}");
        }
        
        return View(model);
    }
}