using BookingSystem.Models;
using BookingSystem.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BookingSystem.Controllers
{
    public class RoomTypeController : Controller
    {
        private readonly IRoomTypeRepo roomTypeRepo;

        public RoomTypeController(IRoomTypeRepo roomTypeRepo)
        {
            this.roomTypeRepo = roomTypeRepo;
        }

        public IActionResult GetAllRoomTypes() => View(roomTypeRepo.GetAll().ToList());


        public IActionResult Details(int id)
        {
            RoomType roomType = roomTypeRepo.FindById(id);
            return View(roomType);
        }
        public IActionResult Delete(int id)
        {
            roomTypeRepo.Delete(id);
            return RedirectToAction("GetAllRoomTypes");
        }
        [HttpGet]
        public IActionResult AddType()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]


        public IActionResult AddType(RoomType NewRoomType)
        {
            if (ModelState.IsValid == true)

            {

                this.roomTypeRepo.Insert(new RoomType()
                {
                    Name = NewRoomType.Name,

                });
                return RedirectToAction("GetAllRoomTypes", NewRoomType);
            }
            return View("AddType", NewRoomType);
        }


        [HttpGet]
        public IActionResult EditRoomType(int id)
        {
            RoomType OldRoomType = roomTypeRepo.FindById(id);
            if (OldRoomType != null)
            {
                return View("EditRoomType", OldRoomType);
            }
            return RedirectToAction("GetAllRoomTypes");
        }
        [HttpPost]
        public IActionResult EditRoomType(int id, RoomType NewRoomType)
        {
            if (ModelState.IsValid == true)
            {
                roomTypeRepo.Edit(id, NewRoomType);
                return RedirectToAction("GetAllRoomTypes");
            }

            return View("EditRoomType", NewRoomType);
        }
    }
}