using Domain.Entities;
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
    public class MealPlanConfgurations : IEntityTypeConfiguration<MealPlan>
    {
        public void Configure(EntityTypeBuilder<MealPlan> builder)
        {
            builder.ToTable("MealPlan");

            builder.Property(e => e.Id).HasColumnName("MealPlanId").UseIdentityColumn().IsRequired();

            builder.Property(e => e.Description).HasMaxLength(1000);

            builder.Property(e => e.Name).HasMaxLength(255);

            builder.HasMany(p => p.MealPlanPrices)
                .WithOne()
                .HasForeignKey(d => d.MealPlanId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_MealPlanPrice_MealPlan");
        }
    }
}
