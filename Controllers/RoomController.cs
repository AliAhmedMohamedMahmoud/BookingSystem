using BookingSystem.Models;
using BookingSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomRepo _roomRepository;

        public RoomController(IRoomRepo roomRepository)
        {
            _roomRepository = roomRepository;
        }


        public IActionResult Index()
        {
            return View(_roomRepository.GetAll());
        }

        public IActionResult Details(int id)
        {
            var room = _roomRepository.FindById(id);
            if (room == null)
            {
                return NotFound();
            }
            return View(room);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Room room)
        {
            if (ModelState.IsValid)
            {
                _roomRepository.Insert(room);
                return RedirectToAction("Index");
            }
            return View(room);
        }

        public IActionResult Edit(int id)
        {
            var room = _roomRepository.FindById(id);
            if (room == null)
            {
                return NotFound();
            }
            return View(room);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Room room)
        {
            if (id != room.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _roomRepository.Edit(id, room);
                return RedirectToAction("Index");
            }
            return View(room);
        }

        public IActionResult Delete(int id)
        {
            var room = _roomRepository.FindById(id);
            if (room == null)
            {
                return NotFound();
            }
            return View(room);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _roomRepository.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
