namespace UmbracoBlogPost.Web.AppCode.Models.CustomEntities;

public class ContactUs
{
    public int Id { get; set; }
    public string? FullName { get; set; }
    public string Email { get; set; }
    public string Subject { get; set; }
    public string Message { get; set; }
}