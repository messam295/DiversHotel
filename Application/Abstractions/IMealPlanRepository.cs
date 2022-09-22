using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions
{
    public interface IMealPlanRepository
    {
        Task<List<MealPlan>> GetMealPlans(CancellationToken cancellationToken);
        Task<MealPlan?> GetMealPlanWithPriceList(int id, CancellationToken cancellationToken);
    }
}
