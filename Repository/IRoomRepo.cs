using BookingSystem.Models;
using System.Collections.Generic;

namespace BookingSystem.Repository
{
    public interface IRoomRepo
    {
        int Delete(int id);
        int Edit(int id, Room room);
        Room FindById(int id);
        List<Room> GetAll();
        int Insert(Room room); 
        List<Room> GetRoomsByBranchId(int id);
        List<Room> GetRoomsByBranchIdAndTypeId(int branchId, int typeId);
        List<Room> GetRoomsByBranchIdAndTypeIdAndStatus(int branchId, int typeId, string status);
        List<Room> GetRoomsByBranchIdAndStatus(int branchId, string status);



    }
}