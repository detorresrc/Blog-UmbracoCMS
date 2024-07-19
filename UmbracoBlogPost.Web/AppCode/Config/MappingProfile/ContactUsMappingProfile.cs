using Umbraco.Cms.Core.Mapping;
using UmbracoBlogPost.Web.AppCode.Models.DTOs;

namespace UmbracoBlogPost.Web.AppCode.Config.MappingProfile;

public class ContactUsMappingProfile : IMapDefinition
{
    public void DefineMaps(IUmbracoMapper mapper)
    {
        mapper.Define<Models.CustomEntities.ContactUs, ContactUsDto>(
            (source, context)
                => new ContactUsDto(),
            (source, target, context) =>
            {
                target.Id = source.Id;
                target.FullName = source.FullName ?? string.Empty;
                target.Email = source.Email;
                target.Subject = source.Subject;
                target.Message = source.Message;
            });
        mapper.Define<ContactUsDto, Models.CustomEntities.ContactUs>((source, context) 
            => new Models.CustomEntities.ContactUs(),
            (source, target, context) =>
            {
                target.Id = source.Id;
                target.FullName = source.FullName;
                target.Email = source.Email;
                target.Subject = source.Subject;
                target.Message = source.Message;
            });
    }
}