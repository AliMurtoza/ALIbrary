using ALIbrary.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ALIbrary.Infrastructure.Data.Configurations;

public class BookCopyConfiguration : IEntityTypeConfiguration<BookCopy>
{
    public void Configure(EntityTypeBuilder<BookCopy> builder)
    {
        builder.ToTable("BookCopies");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Barcode)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasIndex(x => x.Barcode)
            .IsUnique();

        builder.Property(x => x.ShelfLocation)
            .HasMaxLength(100);

        builder.HasOne(x => x.Book)
            .WithMany(x => x.BookCopies)
            .HasForeignKey(x => x.BookId);
    }
}