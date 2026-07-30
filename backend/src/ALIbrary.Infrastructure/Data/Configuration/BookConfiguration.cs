using ALIbrary.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ALIbrary.Infrastructure.Data.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("Books");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(300);

        builder.Property(x => x.ISBN)
            .IsRequired()
            .HasMaxLength(20);

        builder.HasIndex(x => x.ISBN)
            .IsUnique();

        builder.Property(x => x.Description)
            .HasMaxLength(5000);

        builder.Property(x => x.CoverImageUrl)
            .HasMaxLength(1000);

        builder.Property(x => x.AverageRating)
            .HasPrecision(3,2);

        builder.HasOne(x => x.Category)
            .WithMany(x => x.Books)
            .HasForeignKey(x => x.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Publisher)
            .WithMany(x => x.Books)
            .HasForeignKey(x => x.PublisherId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Language)
            .WithMany(x => x.Books)
            .HasForeignKey(x => x.LanguageId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}