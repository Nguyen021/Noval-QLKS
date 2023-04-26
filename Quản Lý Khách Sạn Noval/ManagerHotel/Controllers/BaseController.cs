using ManagerHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManagerHotel.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        protected User GetUserFromSession()
        {
            return (User)Session["user"];
        }

        protected void AddUserToViewBag()
        {
            User user = GetUserFromSession();
            if (user != null)
            {
                ViewBag.User = user;
                ViewBag.Username = user.Username;
            }
            else
            {
                ViewBag.User = null;
                ViewBag.Username = null;
            }
        }
    }
}