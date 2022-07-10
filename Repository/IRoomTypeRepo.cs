using System.Collections.Generic;
using BookingSystem.Models;

namespace BookingSystem.Repository
{
    public interface IRoomTypeRepo
    {
        int Delete(int id);
        int Edit(int id, RoomType roomType);
        RoomType FindById(int id);
        List<RoomType> GetAll();
        int Insert(RoomType roomType);

    }
}
