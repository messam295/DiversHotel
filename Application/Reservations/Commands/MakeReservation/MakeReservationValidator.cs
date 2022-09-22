using Domain.Common;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Reservations.Commands.MakeReservation
{
    public class MakeReservationValidator: AbstractValidator<MakeReservationDto>
    {
        public MakeReservationValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().Length(1, 255);
            
            RuleFor(x => x.Email).NotEmpty().NotNull().EmailAddress().Length(1, 255);
            
            RuleFor(x => x.Country).NotEmpty().NotNull().Length(1, 255);
            
            RuleFor(x => x.NumberOfAdults).InclusiveBetween(default, Constants.MaximumNumberOfAdults);
            
            RuleFor(x => x.NumberOfChildren).InclusiveBetween(default, Constants.MaximumNumberOfChildren);

            RuleFor(x => new { x.NumberOfAdults, x.NumberOfChildren })
                .Must(x => x.NumberOfAdults + x.NumberOfChildren != default)
                .WithMessage("Number of guests should be greater than zero");

            RuleFor(x => x.CheckInDateUtc)
                .LessThan(x => x.CheckOutDateUtc)
                .WithMessage("Check-In date should be before check-out date");

            RuleFor(x => x.CheckOutDateUtc)
                .GreaterThan(x => x.CheckInDateUtc)
                .WithMessage("Check-Out date should be after check-in date");

            RuleFor(x => x.RoomTypeId)
                .GreaterThan(default(int))
                .WithMessage("Room Type is required");

            RuleFor(x => x.MealPlanId)
                .GreaterThan(default(int))
                .WithMessage("Meal Plan is required");

        }
    }
}
