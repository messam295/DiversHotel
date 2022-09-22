using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class RoomTypePrice: BaseEntity
    {
        public int RoomTypeId { get; private set; }
        public decimal PricePerNight { get; private set; }
        public DateOnly FromDateUtc { get; private set; }
        public DateOnly ToDateUtc { get; private set; }

        private RoomTypePrice()
        {
        }
    }
}
