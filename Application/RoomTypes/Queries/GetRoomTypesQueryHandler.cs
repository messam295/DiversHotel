using Application.Abstractions;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RoomTypes.Queries
{
    public class GetRoomTypesQueryHandler : IRequestHandler<GetRoomTypesQuery, List<RoomTypeDto>>
    {
        private readonly IRoomTypeRepository _roomTypeRepository;

        public GetRoomTypesQueryHandler(IRoomTypeRepository roomTypeRepository)
        {
            _roomTypeRepository = roomTypeRepository;
        }

        public async Task<List<RoomTypeDto>> Handle(GetRoomTypesQuery request, CancellationToken cancellationToken)
        {
            var roomTypes = await _roomTypeRepository.GetRoomTypes(cancellationToken);

            return roomTypes.Adapt<List<RoomTypeDto>>();
        }
    }
}
