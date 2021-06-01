using System;

namespace ReservationApi
{
    public class Reservation
    {
        public DateTime Date { get; set; }

        public int Time { get; set; }

        public string Name { get; set; }

        public int NoOfPeople { get; set; }

        public string PhoneNumber { get; set; }
    }
}
