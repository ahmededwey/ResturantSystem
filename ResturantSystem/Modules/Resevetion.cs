using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantSystem.Modules
{
    internal class Reservation
    {
        public int ReservationId { get; set; }
        public string CustomerName { get; set; }
        public int TableCount { get; set; }
        public int ChairCount { get; set; }
        public DateTime ReservationTime { get; set; }

        private static int nextId = 1;

        public Reservation()
        {
            ReservationId = nextId++;
        }

        public override string ToString()
        {
            return $"Reservation #{ReservationId} for {CustomerName} at {ReservationTime} - Tables: {TableCount}, Chairs: {ChairCount}";

        }
    }
}
