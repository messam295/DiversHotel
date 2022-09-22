using Domain.Entities;
using Infrastructure.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityConfigurations
{
    public class ReservationConfigurations : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.ToTable("Reservation");

            builder.Property(e => e.Id).HasColumnName("ReservationId").UseIdentityColumn().IsRequired();

            builder.Property(e => e.CheckInDateUtc)
                .HasColumnType("date")
                .HasConversion<DateOnlyConverter, DateOnlyComparer>();

            builder.Property(e => e.CheckOutDateUtc)
                .HasColumnType("date")
                .HasConversion<DateOnlyConverter, DateOnlyComparer>();

            builder.Property(e => e.Country).HasMaxLength(255);

            builder.Property(e => e.Email).HasMaxLength(255);

            builder.Property(e => e.Name).HasMaxLength(255);

            builder.Property(e => e.TotalAmount).HasColumnType("money");

            builder.HasOne(d => d.MealPlan)
                .WithMany()
                .HasForeignKey(d => d.MealPlanId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reservation_MealPlan");
        }
    }
}
