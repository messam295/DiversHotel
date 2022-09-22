using Application.Abstractions;
using CSharpFunctionalExtensions;
using CSharpFunctionalExtensions.ValueTasks;
using Domain.Abstractions;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Reservations.Commands.MakeReservation
{
    public class MakeReservationCommandHandler : IRequestHandler<MakeReservationCommand, Result<int>>
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IRoomTypeRepository _roomTypeRepository;
        private readonly IMealPlanRepository _mealPlanRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IReservationTotalCalculator _reservationTotalCalculator;

        public MakeReservationCommandHandler(IReservationRepository reservationRepository,
            IRoomTypeRepository roomTypeRepository,
            IMealPlanRepository mealPlanRepository,
            IUnitOfWork unitOfWork,
            IReservationTotalCalculator reservationTotalCalculator)
        {
            _reservationRepository = reservationRepository;
            _roomTypeRepository = roomTypeRepository;
            _mealPlanRepository = mealPlanRepository;
            _unitOfWork = unitOfWork;
            _reservationTotalCalculator = reservationTotalCalculator;
        }

        public async Task<Result<int>> Handle(MakeReservationCommand request, CancellationToken cancellationToken)
        {
            Maybe<MealPlan> maybeMealPlan = (await _mealPlanRepository.GetMealPlanWithPriceList(request.MealPlanId, cancellationToken))!;

            Maybe<Room> maybeAvailableRoom = (await _roomTypeRepository.GetAvailableRoomWithPricesInSpecificPeriod(request.CheckInDateUtc, request.CheckOutDateUtc, request.RoomTypeId, cancellationToken))!;

            var reservationCreationResult = Reservation.MakeReservation(
                request.Name,
                request.Email,
                request.Country,
                request.NumberOfAdults,
                request.NumberOfChildren,
                request.CheckInDateUtc,
                request.CheckOutDateUtc,
                maybeAvailableRoom,
                maybeMealPlan,
                _reservationTotalCalculator);

            if (reservationCreationResult.IsFailure)
                return Result.Failure<int>(reservationCreationResult.Error);

            _reservationRepository.Add(reservationCreationResult.Value);
            await _unitOfWork.SaveChangesAsync();

            return Result.Success(reservationCreationResult.Value.Id);
        }
    }
}
