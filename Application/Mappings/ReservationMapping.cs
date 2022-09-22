using Application.Reservations.Commands.MakeReservation;
using Application.Reservations.Queries.GetReservations;
using Domain.Entities;
using Mapster;

namespace Application.Mappings
{
    public class ReservationMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Reservation, ReservationDto>()
                .Map(dest => dest.MealPlan, src => src.MealPlan.Name)
                .Map(dest => dest.RoomNumber, src => src.Room.RoomNumber);

            config.NewConfig<MakeReservationDto, MakeReservationCommand>()
                .Map(dest => dest.CheckInDateUtc, src => DateOnly.FromDateTime(src.CheckInDateUtc))
                .Map(dest => dest.CheckOutDateUtc, src => DateOnly.FromDateTime(src.CheckOutDateUtc));
        }
    }
}
