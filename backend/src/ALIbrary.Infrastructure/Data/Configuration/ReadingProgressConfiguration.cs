using ALIbrary.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ALIbrary.Infrastructure.Data.Configurations;

public class ReadingProgressConfiguration : IEntityTypeConfiguration<ReadingProgress>
{
    public void Configure(EntityTypeBuilder<ReadingProgress> builder)
    {
        builder.ToTable("ReadingProgress");

        builder.HasKey(x => x.Id);
    }
}