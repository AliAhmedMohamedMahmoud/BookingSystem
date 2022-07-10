using System.Collections.Generic;
using System.Linq;
using BookingSystem.Models;

namespace BookingSystem.Repository
{
    public class HotelBranchRepo: IHotelBranchRepo
    {
        private readonly Entity _context;
        public HotelBranchRepo(Entity context)
        {
            _context = context;
        }
        public int Delete(int id)
        {
            HotelBranch hotelBranch = _context.HotelBranches.Find(id);
            if (hotelBranch == null)
            {
                return 0;
            }
            _context.HotelBranches.Remove(hotelBranch);
            return _context.SaveChanges();
        }
        public HotelBranch FindById(int id)
        {
            return _context.HotelBranches.Find(id);
        }
        public List<HotelBranch> GetAll()
        {
            return _context.HotelBranches.ToList();
        }
        public int Insert(HotelBranch hotelBranch)
        {
            _context.HotelBranches.Add(hotelBranch);
            return _context.SaveChanges();
        }
        public int Edit(int id, HotelBranch hotelBranch)
        {
            HotelBranch hotelBranchToEdit = _context.HotelBranches.Find(id);
            if (hotelBranchToEdit == null)
            {
                return 0;
            }
            hotelBranchToEdit.Address = hotelBranch.Address;
            hotelBranchToEdit.Phone = hotelBranch.Phone;
            return _context.SaveChanges();
        }
    }
}
