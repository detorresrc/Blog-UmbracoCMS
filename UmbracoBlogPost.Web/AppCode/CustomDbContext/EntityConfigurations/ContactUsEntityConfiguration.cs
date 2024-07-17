using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UmbracoBlogPost.Web.AppCode.Models.CustomEntities;

namespace UmbracoBlogPost.Web.AppCode.CustomDbContext.EntityConfigurations;

public class ContactUsEntityConfiguration :IEntityTypeConfiguration<ContactUs>
{
    public void Configure(EntityTypeBuilder<ContactUs> b)
    {
        b.HasKey(x => x.Id);

        b.Property(x => x.FullName)
            .HasMaxLength(256);
        b.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(256);
        b.Property(x => x.Subject)
            .IsRequired()
            .HasMaxLength(512);
        b.Property(x => x.Message)
            .IsRequired();

        b.ToTable("ContactUs");
    }
}