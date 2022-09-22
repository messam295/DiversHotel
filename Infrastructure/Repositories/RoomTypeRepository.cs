using Application.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class RoomTypeRepository : IRoomTypeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public RoomTypeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Room?> GetAvailableRoomWithPricesInSpecificPeriod(
            DateOnly fromDate,
            DateOnly toDate,
            int roomTypeId,
            CancellationToken cancellationToken)
        {
            return _dbContext.Set<Room>()
                .Include(room => room.RoomType)
                .ThenInclude(roomType => roomType.RoomTypePrices)
                .FirstOrDefaultAsync(room => room.RoomTypeId == roomTypeId &&
                    (!room.Reservations.Any(res => 
                        res.CheckInDateUtc <= toDate && res.CheckOutDateUtc >= fromDate) || 
                     room.Reservations.Count == default), cancellationToken);
        }

        public Task<RoomType?> GetRoomTypeWithPriceList(int id, CancellationToken cancellationToken)
        {
            return _dbContext.Set<RoomType>()
                    .Include(r => r.RoomTypePrices)
                    .FirstOrDefaultAsync(r => r.Id == id);
        }

        public Task<List<RoomType>> GetRoomTypes(CancellationToken cancellationToken)
        {
            return _dbContext.Set<RoomType>().ToListAsync(cancellationToken);
        }
    }
}
