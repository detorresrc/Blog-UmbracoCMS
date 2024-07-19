using Umbraco.Cms.Core.Mapping;
using X.PagedList;

namespace UmbracoBlogPost.Web.AppCode.Util;

public static class PageListToResponse
{
    public static ResponseDetails<TDestination> Convert<TSource, TDestination>(IPagedList<TSource> data, IUmbracoMapper mapper)
    {
        var mappedData = mapper.MapEnumerable<TSource, TDestination>(data.ToList());
        
        return new ResponseDetails<TDestination>()
        {
            MetaData = data.GetMetaData(),
            Data = mappedData
        };
    }
}

public class ResponseDetails<TData>
{
    public PagedListMetaData MetaData { get; set; }
    public IEnumerable<TData> Data { get; set; }
}