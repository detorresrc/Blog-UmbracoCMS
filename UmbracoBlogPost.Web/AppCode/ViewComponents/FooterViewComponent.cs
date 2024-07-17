using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Web.Common;
using Umbraco.Cms.Web.Common.PublishedModels;
using UmbracoBlogPost.Web.AppCode.Models.ViewComponentModels;

namespace UmbracoBlogPost.Web.AppCode.ViewComponents;

[ViewComponent]
public class FooterViewComponent(
    ILogger<FooterViewComponent> logger,
    UmbracoHelper helper) : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        FooterVm model = new();
        
        try
        {
            var homePage = helper.ContentAtRoot().FirstOrDefault(x => x.IsDocumentType("home") && x.IsVisible()) as Home;
            if(homePage is null) return View();

            foreach (var itemFooterLink in homePage.FooterLinks)
            {
                model.FooterLinks.Add(new()
                {
                    Name = itemFooterLink.Name,
                    Link = itemFooterLink.Url,
                    Target = itemFooterLink.Target
                });
            }
            
            model.SocialMedia = homePage.SocialMedia;
        }
        catch (Exception e)
        {
            logger.LogError($"Error in FooterViewComponent: {e.Message}");
        }

        return View(model);
    }
}