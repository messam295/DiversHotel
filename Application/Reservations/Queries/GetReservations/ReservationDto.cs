namespace Application.Reservations.Queries.GetReservations
{
    public class ReservationDto
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public int NumberOfAdults { get; set; }
        public int NumberOfChildren { get; set; }
        public DateOnly CheckInDateUtc { get; set; }
        public DateOnly CheckOutDateUtc { get; set; }
        public int RoomId { get; set; }
        public int MealPlanId { get; set; }
        public decimal TotalAmount { get; set; }
        public string MealPlan { get; set; } = string.Empty;
        public string RoomNumber { get; set; } = string.Empty;

    }
}
