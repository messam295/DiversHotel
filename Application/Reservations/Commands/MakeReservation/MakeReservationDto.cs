using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Application.Reservations.Commands.MakeReservation
{
    public class MakeReservationDto
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public int NumberOfAdults { get; set; }
        public int NumberOfChildren { get; set; }
        public DateTime CheckInDateUtc { get; set; } = DateTime.UtcNow;
        public DateTime CheckOutDateUtc { get; set; } = DateTime.UtcNow;
        public int RoomTypeId { get; set; }
        public int MealPlanId { get; set; }
    }
}
