using ALIbrary.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ALIbrary.Infrastructure.Data.Configurations;

public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder.ToTable("Reservations");

        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Member)
            .WithMany(x => x.Reservations)
            .HasForeignKey(x => x.MemberId);

        builder.HasOne(x => x.Book)
            .WithMany(x => x.Reservations)
            .HasForeignKey(x => x.BookId);
    }
}