using ManagerHotel.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace ManagerHotel.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class RoomController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private readonly ApplicationDbContext _context;

        // GET: Room
        public ActionResult Index()
        {
            var rooms = db.Rooms.ToList();
            return View(rooms);
        }
        public ActionResult ListRoom()
        {
            var rooms = db.Rooms.ToList();
            return View(rooms);
        }
        // GET: Room/Details/5 Xem chi tiết
        public ActionResult Details(int id)
        {
            var r = db.Rooms.Where(ro => ro.RoomId == id).FirstOrDefault();
            var r2 = db.Rooms.FirstOrDefault(ro => ro.RoomId == id);
            return View(r);
        }

        // GET: Room/Create // Show Form Create of Room
        public ActionResult Create()
        {
            var roomTypeIds = db.RoomTypes.Select(r => r.RoomTypeId).ToList();
            ViewBag.RoomTypeIds = roomTypeIds;
            return View();
        }

        // POST: Room/Create // Action When Input Data Form Create of Room
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection collection, Room room)
        {
            db.Rooms.Add(room);
            db.SaveChanges();
            return RedirectToAction("ListRoom");
        }

        // GET: Room/Edit/5
        public ActionResult Edit(int id)
        {
            var room = db.Rooms.First(r => r.RoomId == id);
            return View(room);
        }

        // POST: Room/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            
            var ro = db.Rooms.First(r => r.RoomId == id);
            ro.RoomNumber = collection["RoomNumber"];
            ro.Description = collection["Description"];
            if (decimal.TryParse(collection["Price"], out decimal price))
            {
                ro.Price = decimal.Round(price, 2);
            }
           
            ro.FloorNumber = int.Parse(collection["FloorNumber"]);
            ro.Image = collection["Image"];
            //Console.WriteLine(collection["IsActive"]);
            //ro.IsActive = bool.TryParse(collection["IsActive"], out bool isActive) ? isActive : false;


            //ro.IsAvailable = bool.TryParse(collection["IsAvailable"], out bool IsAvailable) ? IsAvailable : false;
            ro.RoomTypeId = int.Parse(collection["RoomTypeId"]);
            
            db.SaveChanges();
            return RedirectToAction("ListRoom");
        }

        // GET: Room/Delete/5
        public ActionResult Delete(int id)
        {
            var room = db.Rooms.First(r => r.RoomId == id);
            return View(room);
        }

        // POST: Room/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var room = db.Rooms.First(r => r.RoomId == id);
            db.Rooms.Remove(room);
            db.SaveChanges();
            return RedirectToAction("ListRoom");
        }
    }
}
