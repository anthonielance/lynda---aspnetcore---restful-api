using System;

namespace LandonAPI.Models
{
    public class Booking : Resource
    {
        public Link Room { get; set; }
        public Link User { get; set; }
        public DateTimeOffset StartAt { get; set; }
        public DateTimeOffset EndAt { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset ModifiedAt { get; set; }
        public decimal Total { get; set; }
    }
}
