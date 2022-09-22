using CSharpFunctionalExtensions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions
{
    public interface IReservationTotalCalculator
    {
        public Result<decimal> GetReservationTotal(DateOnly checkInDate,
            DateOnly checkOutDate,
            int numberOfGuests,
            Maybe<RoomType> roomType,
            Maybe<MealPlan> mealPlan);
    }
}
