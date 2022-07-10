using BookingSystem.Models;
using System;
using System.Collections.Generic;

namespace BookingSystem.ViewModel
{
    public class SearchForAvailableRoomsViewModel
    {
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo{ get; set; }

        public List<Room> Rooms { get; set; }


    }
}
