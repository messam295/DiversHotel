using CSharpFunctionalExtensions;
using Domain.Abstractions;
using Domain.Entities;
using Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ReservationTotalCalculator : IReservationTotalCalculator
    {
        public Result<decimal> GetReservationTotal(
            DateOnly checkInDate,
            DateOnly checkOutDate,
            int numberOfGuests,
            Maybe<RoomType> maybeRoomType,
            Maybe<MealPlan> maybeMealPlan)
        {
            var roomPriceCalculationResult = CalculateRoomPrice(maybeRoomType, checkInDate, checkOutDate);
            if(roomPriceCalculationResult.IsFailure)
                return Result.Failure<decimal>(roomPriceCalculationResult.Error);

            var mealPlanCalculationResult = CalculateMealPlanPrice(maybeMealPlan, checkInDate, checkOutDate, numberOfGuests);
            if (mealPlanCalculationResult.IsFailure)
                return Result.Failure<decimal>(mealPlanCalculationResult.Error);

            var reservationTotal = roomPriceCalculationResult.Value + mealPlanCalculationResult.Value;

            return Result.Success(reservationTotal);
        }

        private Result<decimal> CalculateMealPlanPrice(
            Maybe<MealPlan> maybeMealPlan,
            DateOnly checkInDate,
            DateOnly checkOutDate,
            int numberOfGuests)
        {
            decimal mealPlanPrice = default;

            if (maybeMealPlan.HasNoValue)
                return Result.Failure<decimal>("Meal plan was not found");

            var mealPlan = maybeMealPlan.Value;

            var priceList = mealPlan
                .MealPlanPrices
                .Where(p => p.FromDateUtc <= checkOutDate && p.ToDateUtc >= checkInDate)
                .ToList();

            if (priceList.Count == default)
                return Result.Failure<decimal>($"There are no prices for meal plan {mealPlan.Name} from {checkInDate} to {checkInDate}");

            priceList.ForEach(priceRange =>
            {
                var numberOfDays = DateOnlyHelpers.GetOverlappingDaysBetweenTwoDateRanges(checkInDate, checkOutDate, priceRange.FromDateUtc, priceRange.ToDateUtc);

                mealPlanPrice += numberOfDays * priceRange.PricePerPerson * numberOfGuests;
            });

            return Result.Success(mealPlanPrice);
        }

        private Result<decimal> CalculateRoomPrice(Maybe<RoomType> maybeRoomType,
            DateOnly checkInDate, 
            DateOnly checkOutDate)
        {
            decimal roomPrice = default;

            if (maybeRoomType.HasNoValue)
                return Result.Failure<decimal>("Room type was not found");

            var roomType = maybeRoomType.Value;

            var priceList = roomType
                .RoomTypePrices
                .Where(p => p.FromDateUtc <= checkOutDate && p.ToDateUtc >= checkInDate)
                .ToList();

            if(priceList.Count == default)
                return Result.Failure<decimal>($"There are no prices for room type {roomType.RoomTypeName} from {checkInDate} to {checkInDate}");            

            priceList.ForEach(priceRange => 
            {
                var numberOfDays = DateOnlyHelpers.GetOverlappingDaysBetweenTwoDateRanges(checkInDate, checkOutDate, priceRange.FromDateUtc, priceRange.ToDateUtc);

                roomPrice += numberOfDays * priceRange.PricePerNight;
            });

            return Result.Success(roomPrice);
        }
    }
}
