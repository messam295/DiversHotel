using CSharpFunctionalExtensions;
using MediatR;

namespace Application.Reservations.Commands.MakeReservation
{
    public class MakeReservationCommand : IRequest<Result<int>>
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public int NumberOfAdults { get; set; }
        public int NumberOfChildren { get; set; }
        public int RoomTypeId { get; set; }
        public int MealPlanId { get; set; }
        public DateOnly CheckInDateUtc { get; set; }
        public DateOnly CheckOutDateUtc { get; set; }
    }
}
