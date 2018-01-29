using System;

namespace LandonAPI.Models
{
    public class OpeningEntity : BookingRange
    {
        public Guid RoomId { get; set; }
        public int Rate { get; set; }
    }
}
