using Domain.Abstractions;
using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class RoomType: BaseEntity, IAggregateRoot
    {
        private RoomType()
        {
        }

        public string RoomTypeName { get; private set; } = string.Empty;

        public ICollection<RoomTypePrice> RoomTypePrices { get; } = new HashSet<RoomTypePrice>();
        public ICollection<Room> Rooms { get; } = new HashSet<Room>();
    }
}
