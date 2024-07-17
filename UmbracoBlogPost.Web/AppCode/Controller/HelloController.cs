using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Web.Common.Controllers;

namespace UmbracoBlogPost.Web.AppCode.Controller;

public class HelloController : UmbracoApiController
{
    public IActionResult HelloWorld()
    {
        return Ok("Hello World");
    }
}