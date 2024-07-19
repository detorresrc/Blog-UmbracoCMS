using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Api.Common.Attributes;
using Umbraco.Cms.Core.Mapping;
using Umbraco.Cms.Persistence.EFCore.Scoping;
using Umbraco.Cms.Web.BackOffice.Controllers;
using UmbracoBlogPost.Web.AppCode.CustomDbContext;
using UmbracoBlogPost.Web.AppCode.Models.DTOs;
using UmbracoBlogPost.Web.AppCode.Util;
using X.PagedList.Extensions;

namespace UmbracoBlogPost.Web.App_Plugins.ContactUs;

[ApiController]
[Route("umbraco/backoffice/api/contactus")]
public class ContactUsController(
    IEFCoreScopeProvider<ApplicationDbContext> scopeProvider,
    IUmbracoMapper mapper) : UmbracoAuthorizedApiController
{
    
    [HttpGet]
    [ProducesResponseType(typeof(ResponseDetails<ContactUsDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Index([FromQuery]int page=1, [FromQuery]string? searchTerm=null)
    {
        using IEfCoreScope<ApplicationDbContext> scope = scopeProvider.CreateScope();

        var data = await scope.ExecuteWithContextAsync(db =>
        {
            IQueryable<AppCode.Models.CustomEntities.ContactUs> query = db.ContactUs.AsQueryable();

            var data = query.ToPagedList(page, 2);

            return Task.FromResult(data);
        });
        
        scope.Complete();

        return Ok(
            PageListToResponse.Convert<AppCode.Models.CustomEntities.ContactUs, ContactUsDto>(data, mapper)
        );
    }
    
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(ContactUsDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetById(int id)
    {
        using IEfCoreScope<ApplicationDbContext> scope = scopeProvider.CreateScope();

        var data = await scope.ExecuteWithContextAsync(db =>
        {
            var contactUs = db.ContactUs.FirstOrDefault(x => x.Id == id);

            return Task.FromResult(contactUs);
        });

        scope.Complete();

        if (data == null)
        {
            return NotFound();
        }

        return Ok(mapper.Map<ContactUsDto>(data));
    } 
}