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
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //public class HomeViewModel
        //{
        //    public List<Room> Rooms { get; set; }
        //}
        public ActionResult Index()
        {
            GetUser getUser = new GetUser();
            int userId = ManagerCookies.GetUserIdFromCookies();
            User user = getUser.GetUserById(userId);

            if (user != null)
            {
                ViewBag.User = user;
                ViewBag.Username = user.Username;
                ViewBag.UserType = user.UserType;
            }
            else
            {
                ViewBag.User = null;
            }

            var rooms = db.Rooms.ToList();
            ViewBag.Rooms = rooms;
            //var viewModel = new HomeViewModel { Rooms = rooms };
            //ViewBag.Rooms = viewModel;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}