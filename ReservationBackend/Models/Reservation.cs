using System;
namespace ReservationBackend.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int ProviderId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsConfirmed { get; set; }
        public DateTime ReservationTime { get; set; }
    }

}

