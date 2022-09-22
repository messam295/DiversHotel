using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Room: BaseEntity
    {
        public string RoomNumber { get; private set; } = string.Empty;
        public int RoomTypeId { get; private set; }

        public RoomType RoomType { get; private set; } = null!;

        public ICollection<Reservation> Reservations { get; }

        private Room()
        {

        }
    }
}
