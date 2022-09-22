using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions
{
    public interface IRoomTypeRepository
    {
        Task<List<RoomType>> GetRoomTypes(CancellationToken cancellationToken);
        Task<RoomType?> GetRoomTypeWithPriceList(int id, CancellationToken cancellationToken);
        Task<Room?> GetAvailableRoomWithPricesInSpecificPeriod(DateOnly fromDate, DateOnly toDate, int roomTypeId, CancellationToken cancellationToken);
    }
}
