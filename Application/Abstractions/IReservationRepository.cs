﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions
{
    public interface IReservationRepository
    {
        Task<List<Reservation>> GetReservations(int pageNumber, int pageSize, CancellationToken cancellationToken);
        void Add(Reservation reservation);
    }
}
