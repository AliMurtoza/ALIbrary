using ALIbrary.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ALIbrary.Infrastructure.Data.Configurations;

public class LoanConfiguration : IEntityTypeConfiguration<Loan>
{
    public void Configure(EntityTypeBuilder<Loan> builder)
    {
        builder.ToTable("Loans");

        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Member)
            .WithMany(x => x.Loans)
            .HasForeignKey(x => x.MemberId);

        builder.HasOne(x => x.BookCopy)
            .WithMany(x => x.Loans)
            .HasForeignKey(x => x.BookCopyId);
    }
}