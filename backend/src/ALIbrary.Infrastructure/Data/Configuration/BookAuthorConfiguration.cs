using ALIbrary.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ALIbrary.Infrastructure.Data.Configurations;

public class BookAuthorConfiguration : IEntityTypeConfiguration<BookAuthor>
{
    public void Configure(EntityTypeBuilder<BookAuthor> builder)
    {
        builder.ToTable("BookAuthors");

        builder.HasKey(x => x.Id);

        builder.HasIndex(x => new { x.BookId, x.AuthorId }).IsUnique();

        builder.HasOne(x => x.Book)
            .WithMany(x => x.BookAuthors)
            .HasForeignKey(x => x.BookId);

        builder.HasOne(x => x.Author)
            .WithMany(x => x.BookAuthors)
            .HasForeignKey(x => x.AuthorId);
    }
}