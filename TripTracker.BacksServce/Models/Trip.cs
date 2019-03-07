using System;

namespace TripTracker.BacksServce.Models
{
    public class Trip
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndtDate { get; set; }
    }
}
