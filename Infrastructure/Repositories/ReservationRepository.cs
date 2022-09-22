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
    public class ReservationRepository : IReservationRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ReservationRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Reservation reservation)
        {
            _dbContext.Add(reservation);
        }

        public Task<List<Reservation>> GetReservations(int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            return _dbContext.Set<Reservation>()
                    .Include(r => r.Room)
                    .Include(r => r.MealPlan)
                    .AsNoTracking()
                    .Skip(pageSize * (pageNumber - 1))
                    .Take(pageSize)
                    .ToListAsync(cancellationToken);
        }
    }
}
