using ManagerHotel.Common;
using ManagerHotel.Configs;
using ManagerHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ManagerHotel.Controllers
{
    public class HomeController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //public class HomeViewModel
        //{
        //    public List<Room> Rooms { get; set; }
        //}
        public ActionResult Index(string searchString)
        {
            GetUser getUser = new GetUser();
            int userId = ManagerCookies.GetUserIdFromCookies();
            User user = getUser.GetUserById(userId);
            
            if (user != null)
            {
                Session["User"] = user;
                ViewBag.User = user;
                ViewBag.Username = user.Username;
                ViewBag.UserType = user.UserType;
            }
            else
            {
                Session["User"] = null;
                ViewBag.User = null;
            }
            var rooms = db.Rooms.Where(r => r.IsActive == true).ToList();

            if (!String.IsNullOrEmpty(searchString))
            {
                rooms = rooms.Where(r => r.Description.Contains(searchString)).ToList();

            }
            
            ViewBag.Rooms = rooms;
            //var viewModel = new HomeViewModel { Rooms = rooms };
            //ViewBag.Rooms = viewModel;

            return View();
        }

        public ActionResult About()
        {
            AddUserToViewBag();
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            AddUserToViewBag();
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult BookRoom(int id ,DateTime checkInDate, decimal price)
        {
            User user = (User)Session["User"];
            if (user == null)
            { 
                return RedirectToAction("Login", "User");
            }
            Room room = db.Rooms.Find(id);
            if (room == null)
            {
                // Nếu không tìm thấy phòng, redirect đến trang thông báo lỗi
                return RedirectToAction("Error", "Home");
            }
            Booking booking = new Booking
            {
                RoomId = id,
                CheckInDate = checkInDate,
                
                CustomerId = (int)user.CustomerId,
                TotalPrice = price,
                Type = user.UserType == UserType.Customer? 2:1,
                Status = 0
            };
            try {
                db.Bookings.Add(booking);
                db.SaveChanges();
                ViewBag.BookingId = booking.BookingId;
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return this.View();
            }
            return this.View();
        }
    }
}