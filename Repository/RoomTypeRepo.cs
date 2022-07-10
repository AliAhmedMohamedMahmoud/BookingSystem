using System.Collections.Generic;
using System.Linq;
using BookingSystem.Models;

namespace BookingSystem.Repository
{
    public class RoomTypeRepo :IRoomTypeRepo
    {
        Entity context;
        public RoomTypeRepo(Entity _context)
        {
            context = _context;
        }
        public List<RoomType> GetAll()
        {
            return context.RoomTypes.ToList();
        }
        public RoomType FindById(int id)
        {
            return context.RoomTypes.FirstOrDefault(x => x.Id == id);
        }
        public int Insert(RoomType roomType)
        {
            context.RoomTypes.Add(roomType);
            return context.SaveChanges();
        }

        public int Discount(int id, int discount)
        {
            throw new System.NotImplementedException();
        }

        public int Edit(int id, RoomType roomType)
        {
            RoomType oldRoomType = FindById(id);
            if (oldRoomType != null)
            {
                oldRoomType.Name = roomType.Name;
                return context.SaveChanges();
            }
            return 0;
        }
        public int Delete(int id)
        {
            RoomType delRoomType = FindById(id);
            if (delRoomType != null)
            {
                context.RoomTypes.Remove(delRoomType);
                return context.SaveChanges();
            }
            return 0;
        }
    }

 }
