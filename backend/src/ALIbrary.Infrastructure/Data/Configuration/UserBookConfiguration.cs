using ALIbrary.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ALIbrary.Infrastructure.Data.Configurations;

public class UserBookConfiguration : IEntityTypeConfiguration<UserBook>
{
    public void Configure(EntityTypeBuilder<UserBook> builder)
    {
        builder.ToTable("UserBooks");

        builder.HasKey(x => x.Id);

        builder.HasIndex(x => new { x.MemberId, x.BookId }).IsUnique();

        builder.HasOne(x => x.Member)
            .WithMany(x => x.UserBooks)
            .HasForeignKey(x => x.MemberId);

        builder.HasOne(x => x.Book)
            .WithMany(x => x.UserBooks)
            .HasForeignKey(x => x.BookId);

        builder.HasOne(x => x.ReadingProgress)
            .WithOne(x => x.UserBook)
            .HasForeignKey<ReadingProgress>(x => x.UserBookId);

        builder.HasOne(x => x.BookReview)
            .WithOne(x => x.UserBook)
            .HasForeignKey<BookReview>(x => x.UserBookId);
    }
}