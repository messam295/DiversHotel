using CSharpFunctionalExtensions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityConfigurations
{
    internal class RoomTypeConfigurations : IEntityTypeConfiguration<RoomType>
    {
        public void Configure(EntityTypeBuilder<RoomType> builder)
        {
            builder.ToTable("RoomType");

            builder.Property(e => e.Id).HasColumnName("RoomTypeId").UseIdentityColumn().IsRequired();

            builder.Property(e => e.RoomTypeName).HasMaxLength(255);

            builder.HasMany(p => p.RoomTypePrices)
                .WithOne()
                .HasForeignKey(d => d.RoomTypeId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_RoomTypePrice_RoomType");
        }
    }
}
