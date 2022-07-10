using System.Collections.Generic;
using BookingSystem.Models;

namespace BookingSystem.Repository
{
    public interface IHotelBranchRepo
    {
        int Delete(int id);
        int Edit(int id, HotelBranch hotelBranch);
        HotelBranch FindById(int id);
        List<HotelBranch> GetAll();
        int Insert(HotelBranch hotelBranch);
    }
}
