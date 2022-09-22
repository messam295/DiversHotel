using Application.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class MealPlanRepository : IMealPlanRepository
    {
        private readonly ApplicationDbContext _dbContext;
        
        public MealPlanRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<MealPlan>> GetMealPlans(CancellationToken cancellationToken)
        {
            return _dbContext.Set<MealPlan>().ToListAsync(cancellationToken);
        }

        public Task<MealPlan?> GetMealPlanWithPriceList(int id, CancellationToken cancellationToken)
        {
            return _dbContext.Set<MealPlan>()
                .Include(m => m.MealPlanPrices)
                .FirstOrDefaultAsync(m => m.Id == id, cancellationToken);
        }
    }
}
