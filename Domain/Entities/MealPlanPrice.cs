using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class MealPlanPrice: BaseEntity
    {
        public decimal PricePerPerson { get; private set; }
        public DateOnly FromDateUtc { get; private set; }
        public DateOnly ToDateUtc { get; private set; }
        public int MealPlanId { get; set; }

        private MealPlanPrice()
        {

        }
    }
}
