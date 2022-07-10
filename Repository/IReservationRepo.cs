using System.Collections.Generic;
using BookingSystem.Models;

namespace BookingSystem.Repository
{
    public interface IReservationRepo
    {
        IEnumerable<Reservation> GetAll();
        Reservation FindById(int id);
        int Insert(Reservation reservation);
        int Edit(int id, Reservation reservation);
        int Delete(int id);
        int DiscountByUserId(string userId, int discount);
        
    }
}
