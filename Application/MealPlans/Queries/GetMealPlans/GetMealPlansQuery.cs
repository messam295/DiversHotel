using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MealPlans.Queries.GetMealPlans
{
    public class GetMealPlansQuery : IRequest<List<MealPlanDto>>
    {
    }
}
