using ALIbrary.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ALIbrary.Infrastructure.Data.Configurations;

public class BookshelfBookConfiguration : IEntityTypeConfiguration<BookshelfBook>
{
    public void Configure(EntityTypeBuilder<BookshelfBook> builder)
    {
        builder.ToTable("BookshelfBooks");

        builder.HasKey(x => x.Id);

        builder.HasIndex(x => new { x.BookshelfId, x.UserBookId }).IsUnique();

        builder.HasOne(x => x.Bookshelf)
            .WithMany(x => x.BookshelfBooks)
            .HasForeignKey(x => x.BookshelfId);

        builder.HasOne(x => x.UserBook)
            .WithMany(x => x.BookshelfBooks)
            .HasForeignKey(x => x.UserBookId);
    }
}