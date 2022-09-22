using Domain.Abstractions;
using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class MealPlan: BaseEntity, IAggregateRoot
    {
        private MealPlan()
        {
        }

        public string Name { get; private set; } = string.Empty;
        public string? Description { get; private set; }

        public ICollection<MealPlanPrice> MealPlanPrices { get; } = new HashSet<MealPlanPrice>();
    }
}
