using CSharpFunctionalExtensions;
using Domain.Entities;
using Infrastructure.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityConfigurations
{
    public class RoomTypePriceConfigurations : IEntityTypeConfiguration<RoomTypePrice>
    {
        public void Configure(EntityTypeBuilder<RoomTypePrice> builder)
        {
            builder.ToTable("RoomTypePrice");

            builder.Property(e => e.Id).HasColumnName("RoomTypePriceId").UseIdentityColumn().IsRequired();

            builder.Property(e => e.FromDateUtc)
                .HasColumnType("date")
                .HasConversion<DateOnlyConverter, DateOnlyComparer>();

            builder.Property(e => e.ToDateUtc)
                .HasColumnType("date")
            .HasConversion<DateOnlyConverter, DateOnlyComparer>();

            builder.Property(e => e.PricePerNight).HasColumnType("money");
        }
    }
}
