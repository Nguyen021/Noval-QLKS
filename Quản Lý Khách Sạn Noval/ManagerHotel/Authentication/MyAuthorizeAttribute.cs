using ManagerHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ManagerHotel.Authentication
{
    public class MyAuthorizeAttribute : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            User user = (User)filterContext.HttpContext.Session["User"];
            if (user == null)
            {
                // Chưa đăng nhập, redirect đến trang đăng nhập
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new { controller = "Account", action = "Login" }));
            }
            else if (user.UserType != UserType.Admin)
            {
                // Redirect đến trang permission denied
                filterContext.Result = new ViewResult { ViewName = "Error403" };
            }
        }
    }
}