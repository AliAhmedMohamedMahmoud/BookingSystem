using BookingSystem.Models;
using BookingSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationRepo _repo;

        public ReservationController(IReservationRepo repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            return View(_repo.GetAll());
        }

        public IActionResult Details(int id)
        {
            var reservation = _repo.FindById(id);
            if (reservation == null)
            {
                return NotFound();
            }
            return View(reservation);
            }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Reservation reservation)
        {
            Reservation reservationModel = new Reservation()
            {
                UserId = reservation.UserId,
                EndDate = reservation.EndDate,
                StartDate = reservation.StartDate,
            };
            if (ModelState.IsValid)
            {
                _repo.Insert(reservation);
                return RedirectToAction("Index");
            }
            return View(reservation);
        }

        public IActionResult Edit(int id)
        {
            var reservation = _repo.FindById(id);
            if (reservation == null)
            {
                return NotFound();
            }
            return View(reservation);
        }

        [HttpPost]
        public IActionResult Edit(int id, Reservation reservation)
        {
            if (id != reservation.Id)
            {
                return NotFound();
            }
            var reservationToEdit = _repo.FindById(id);
            if (reservationToEdit == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _repo.Edit(id, reservation);
                return RedirectToAction("Index");
            }
            return View(reservation);
        }

        public IActionResult Delete(int id)
        {
            return View(_repo.FindById(id));
        }

        [HttpPost]
        public IActionResult Delete(int id, Reservation reservation)
        {
            _repo.Delete(id);
            return RedirectToAction("Index");
        }
        
    }
}
