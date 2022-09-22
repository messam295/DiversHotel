using Application.Reservations.Queries.GetReservations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DiversHotel.Pages.Reservations
{
    public class IndexModel : PageModel
    {
        private readonly IMediator _mediator;

        public List<ReservationDto> Reservations { get; set; } = Enumerable.Empty<ReservationDto>().ToList();

        public IndexModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<PageResult> OnGet([FromQuery] GetReservationsQuery query)
        {
            Reservations = await _mediator.Send(query);

            return Page();
        }
    }
}
