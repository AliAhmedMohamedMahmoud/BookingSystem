using System.Linq;
using BookingSystem.Models;
using BookingSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.Controllers
{
    public class HotelBranchController : Controller
    {
        private readonly IHotelBranchRepo _hotelBranchRepository;

        public HotelBranchController(IHotelBranchRepo hotelBranchRepository)
        {
            _hotelBranchRepository = hotelBranchRepository;
        }

        public IActionResult Index()
        {
            var hotelBranches = _hotelBranchRepository.GetAll();
            return View(hotelBranches);
        }

        public IActionResult Details(int id)
        {
            var hotelBranch = _hotelBranchRepository.FindById(id);
            if (hotelBranch == null)
            {
                return NotFound();
            }

            return View(hotelBranch);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(HotelBranch hotelBranch)
        {
            if (ModelState.IsValid)
            {
                _hotelBranchRepository.Insert(hotelBranch);
                return RedirectToAction("Index");
            }

            return View(hotelBranch);
        }

        public IActionResult Edit(int id)
        {

            var hotelBranch = _hotelBranchRepository.FindById(id);
            if (hotelBranch == null)
            {
                return NotFound();
            }

            return View(hotelBranch);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, HotelBranch hotelBranch)
        {
            if (id != hotelBranch.Id)
            {
                return NotFound();
            }

            HotelBranch hotelBranch2 = _hotelBranchRepository.FindById(id);
            if (hotelBranch2 == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _hotelBranchRepository.Edit(id, hotelBranch);
                return RedirectToAction("Index");
            }

            return View(hotelBranch);
        }

        public IActionResult Delete(int id)
        {
            var hotelBranch = _hotelBranchRepository.FindById(id);
            return View(hotelBranch);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _hotelBranchRepository.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Search(string searchString)
        {
            var hotelBranches = _hotelBranchRepository.GetAll();
            if (!string.IsNullOrEmpty(searchString))
            {
                hotelBranches = hotelBranches.Where(h => h.Name.ToLower().Contains(searchString.ToLower())).ToList();
            }

            return View(hotelBranches);
        }

        public IActionResult SearchByAddrees(string searchString)
        {
            var hotelBranches = _hotelBranchRepository.GetAll();
            if (!string.IsNullOrEmpty(searchString))
            {
                hotelBranches = hotelBranches.Where(h => h.Address.ToLower().Contains(searchString.ToLower())).ToList();
            }

            return View(hotelBranches);

        }
    }
}
