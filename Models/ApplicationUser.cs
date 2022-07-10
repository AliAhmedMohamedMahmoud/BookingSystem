using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace BookingSystem.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual List<Reservation> Reservations { get; set; }
    }
}
