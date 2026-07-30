using ALIbrary.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ALIbrary.Infrastructure.Data.Configurations;

public class BookshelfConfiguration : IEntityTypeConfiguration<Bookshelf>
{
    public void Configure(EntityTypeBuilder<Bookshelf> builder)
    {
        builder.ToTable("Bookshelves");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(x => x.Description)
            .HasMaxLength(1000);

        builder.HasOne(x => x.Member)
            .WithMany(x => x.Bookshelves)
            .HasForeignKey(x => x.MemberId);
    }
}