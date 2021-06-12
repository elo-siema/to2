using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheShow.Domain;

namespace TheShow.Infrastructure.Configurations
{
    public class UserReservationConfiguration : IEntityTypeConfiguration<UserReservation>
    {
        public void Configure(EntityTypeBuilder<UserReservation> builder)
        {
            builder.ToTable("UserReservations");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Reservations)
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.MovieShowcase)
                .WithMany(x => x.MadeReservations)
                .HasForeignKey(x => x.MovieShowcaseId);
        }
    }
}
