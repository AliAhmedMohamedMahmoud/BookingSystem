using System;
using BookingSystem.Models;
using System.Collections.Generic;
using System.Linq;

namespace BookingSystem.Repository
{
    public class RoomRepo : IRoomRepo
    {

        Entity context;
        public RoomRepo(Entity _context)
        {
            context = _context;
        }

        public List<Room> GetAll()
        {
            return context.Rooms.ToList();
        }
        public Room FindById(int id)
        {
            return context.Rooms.FirstOrDefault(x => x.Id == id);
        }
        public int Insert(Room room)
        {
            context.Rooms.Add(room);
            return context.SaveChanges();
        }
        public int Edit(int id, Room room)
        {
            Room oldRoom = FindById(id);
            if (oldRoom != null)
            {
                oldRoom.Status = room.Status;
                oldRoom.Price = room.Price;
                oldRoom.Description = room.Description;
                oldRoom.BranchId = room.BranchId;
                room.ReservationId = oldRoom.ReservationId;
                oldRoom.TypeId = room.TypeId;

                return context.SaveChanges();
            }
            return 0;
        }
        public int Delete(int id)
        {
            Room delRoom = FindById(id);
            if (delRoom != null)
            {
                context.Rooms.Remove(delRoom);
                return context.SaveChanges();
            }
            return 0;
          }

        public List<Room> GetRoomsByBranchId(int id)
        {
            return context.Rooms.Where(x => x.BranchId == id).ToList();
        }
        
        public List<Room> GetRoomsByBranchIdAndTypeId(int branchId, int typeId)
        {
            return context.Rooms.Where(x => x.BranchId == branchId && x.TypeId == typeId).ToList();
        }

        public List<Room> GetRoomsByBranchIdAndTypeIdAndStatus(int branchId, int typeId, string status)
        {
            return context.Rooms.Where(x => x.BranchId == branchId && x.TypeId == typeId && x.Status == status).ToList();
        }

        public List<Room> GetRoomsByBranchIdAndStatus(int branchId, string status)
        {
            return context.Rooms.Where(x => x.BranchId == branchId && x.Status == status).ToList();
        }
        

    }
}
