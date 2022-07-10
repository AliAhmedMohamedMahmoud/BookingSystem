using System.Collections.Generic;
using System.Linq;
using BookingSystem.Models;

namespace BookingSystem.Repository
{
    public class ReservationRepo: IReservationRepo 
    {
        Entity context;
        public ReservationRepo(Entity _context)
        {
            context = _context;
        }
        public IEnumerable<Reservation> GetAll()
        {
            return context.Reservations.ToList();
        }
        public Reservation FindById(int id)
        {
            return context.Reservations.FirstOrDefault(x => x.Id == id);
        }
        public int Insert(Reservation reservation)
        {
            context.Reservations.Add(reservation);
            return context.SaveChanges();
        }

        public int Edit(int id, Reservation reservation)
        {
            Reservation oldReservation = FindById(id);
            if (oldReservation != null)
            {
                oldReservation.Id = reservation.Id;
                oldReservation.UserId = reservation.UserId;
                oldReservation.StartDate = reservation.StartDate;
                oldReservation.EndDate = reservation.EndDate;
                return context.SaveChanges();
            }
            return 0;
        }
        public int Delete(int id)
        {
            Reservation delReservation = FindById(id);
            if (delReservation != null)
            {
                context.Reservations.Remove(delReservation);
                return context.SaveChanges();
            }
            return 0;
        }

        public int DiscountByUserId(string userId, int discount)
        {
            Reservation oldReservation = context.Reservations.FirstOrDefault(x => x.UserId == userId);
            if (oldReservation != null)
            {
                oldReservation.Discount = discount;
                return context.SaveChanges();
            }
            return 0;
        }
        
        

    }
}
