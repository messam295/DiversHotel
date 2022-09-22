using CSharpFunctionalExtensions;
using Domain.Abstractions;
using Domain.Common;
namespace Domain.Entities
{
    public class Reservation : BaseEntity, IAggregateRoot
    {
        public string Name { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string Country { get; private set; } = string.Empty;
        public int NumberOfAdults { get; private set; }
        public int NumberOfChildren { get; private set; }
        public DateOnly CheckInDateUtc { get; private set; }
        public DateOnly CheckOutDateUtc { get; private set; }
        public int RoomId { get; private set; }
        public int MealPlanId { get; private set; }
        public decimal TotalAmount { get; private set; }

        public MealPlan MealPlan { get; private set; } = null!;
        public Room Room { get; private set; } = null!;

        private Reservation()
        {

        }

        public static Result<Reservation> MakeReservation(
            string name,
            string email,
            string country,
            int numberOfAdults,
            int numberOfChildren,
            DateOnly checkInDate,
            DateOnly checkOutDate,
            Maybe<Room> maybeRoom,
            Maybe<MealPlan> maybeMealPlan,
            IReservationTotalCalculator reservationTotalCalculator)
        {
            var validationResult = Validate(numberOfAdults, 
                    numberOfChildren,
                    maybeRoom,
                    maybeMealPlan);

            if (validationResult.IsFailure)
                return Result.Failure<Reservation>(validationResult.Error);

            var totalAmountCalculationResult = reservationTotalCalculator.GetReservationTotal(checkInDate, 
                checkOutDate,
                numberOfAdults + numberOfChildren,
                maybeRoom.Value.RoomType,
                maybeMealPlan.Value);

            if (totalAmountCalculationResult.IsFailure)
                return Result.Failure<Reservation>(totalAmountCalculationResult.Error);

            Reservation newReservation = new()
            {
                Name = name,
                Email = email,
                Country = country,
                NumberOfAdults = numberOfAdults,
                NumberOfChildren = numberOfChildren,
                CheckInDateUtc = checkInDate,
                CheckOutDateUtc = checkOutDate,
                RoomId = maybeRoom.Value.Id,
                MealPlanId = maybeMealPlan.Value.Id,
                TotalAmount = totalAmountCalculationResult.Value
            };

            return Result.Success(newReservation);
        }

        private static Result Validate(
            int numberOfAdults,
            int numberOfChildren,
            Maybe<Room> maybeRoom,
            Maybe<MealPlan> maybeMealPlan)
        {
            if (maybeRoom.HasNoValue)
                return Result.Failure($"No available room was not found (try to change period or room type)");

            if (maybeRoom.Value.RoomType is null)
                return Result.Failure("Room type was not found");

            if (maybeMealPlan.HasNoValue)
                return Result.Failure("Meal plan was not found");

            if (numberOfAdults > Constants.MaximumNumberOfAdults)
                return Result.Failure($"Maximum number of adults is {Constants.MaximumNumberOfAdults}");

            if (numberOfChildren > Constants.MaximumNumberOfChildren)
                return Result.Failure($"Maximum number of children is {Constants.MaximumNumberOfChildren}");

            return Result.Success();
        }
    }
}
