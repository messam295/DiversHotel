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
    public class MealPlanPriceConfigurations : IEntityTypeConfiguration<MealPlanPrice>
    {
        public void Configure(EntityTypeBuilder<MealPlanPrice> builder)
        {
            builder.ToTable("MealPlanPrice");

            builder.Property(e => e.Id).HasColumnName("MealPlanPriceId").UseIdentityColumn().IsRequired();

            builder.Property(e => e.FromDateUtc)
                .HasColumnType("date")
            .HasConversion<DateOnlyConverter, DateOnlyComparer>(); ;

            builder.Property(e => e.PricePerPerson).HasColumnType("money");

            builder.Property(e => e.ToDateUtc)
                .HasColumnType("date")
                .HasConversion<DateOnlyConverter, DateOnlyComparer>();
        }
    }
}
