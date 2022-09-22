using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RoomTypes.Queries
{
    public class GetRoomTypesQuery: IRequest<List<RoomTypeDto>>
    {
    }
}
