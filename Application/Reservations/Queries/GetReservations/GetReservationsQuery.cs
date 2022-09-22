using Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Reservations.Queries.GetReservations
{
    public class GetReservationsQuery : IRequest<List<ReservationDto>>
    {
        public int PageNumber { get; set; } = Constants.DefaultPageNumber;
        public int PageSize { get; set; } = Constants.DefaultPageSize;
    }
}
