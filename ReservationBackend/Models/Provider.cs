using System;
namespace ReservationBackend.Models
{
    // Provider model
    public class Provider
    {
        public int Id { get; set; }
        public List<TimeSlot> Schedule { get; set; }
    }

    // TimeSlot model
    public class TimeSlot
    {
        public int Id { set; get; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }

}

