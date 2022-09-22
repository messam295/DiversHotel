using Application.MealPlans.Queries.GetMealPlans;
using Application.Reservations.Commands.MakeReservation;
using Application.RoomTypes.Queries;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DiversHotel.Pages.Reservations
{
    public class CreateModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        [BindProperty]
        public MakeReservationDto ReservationDto { get; set; } = new();
        
        public List<MealPlanDto> MealPlans = Enumerable.Empty<MealPlanDto>().ToList();
        public List<RoomTypeDto> RoomTypes = Enumerable.Empty<RoomTypeDto>().ToList();
        
        public CreateModel(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task OnGet()
        {
            await FillLists();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                await FillLists();
                return Page();
            }

            var command = _mapper.Map<MakeReservationCommand>(ReservationDto);

            var makingReservation = await _mediator.Send(command);
            if (makingReservation.IsFailure)
            {
                await FillLists();
                TempData["Error"] = makingReservation.Error;
                return Page();
            }

            TempData["Message"] = "Created Successfully";

            return RedirectToPage("Index");
        }
        
        private async Task FillLists() 
        {
            MealPlans = await _mediator.Send(new GetMealPlansQuery());
            RoomTypes = await _mediator.Send(new GetRoomTypesQuery());
        }
    }
}
