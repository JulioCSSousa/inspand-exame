using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Mappings;

public class BookMapping : EntityTypeConfiguration<Book>
{
    public override void Configure(EntityTypeBuilder<Book> builder)
    {
        base.Configure(builder);

        builder.ToTable("Books");

        builder.Property(p => p.Title)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(p => p.Author)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(p => p.Description)
            .HasMaxLength(1000);
    }
}
