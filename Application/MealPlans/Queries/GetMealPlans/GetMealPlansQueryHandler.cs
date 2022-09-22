using Application.Abstractions;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MealPlans.Queries.GetMealPlans
{
    internal class GetMealPlansQueryHandler : IRequestHandler<GetMealPlansQuery, List<MealPlanDto>>
    {
        private readonly IMealPlanRepository _mealPlanRepository;

        public GetMealPlansQueryHandler(IMealPlanRepository mealPlanRepository)
        {
            _mealPlanRepository = mealPlanRepository;
        }

        public async Task<List<MealPlanDto>> Handle(GetMealPlansQuery request, CancellationToken cancellationToken)
        {
            var mealPlans = await _mealPlanRepository.GetMealPlans(cancellationToken);

            return mealPlans.Adapt<List<MealPlanDto>>();
        }
    }
}
