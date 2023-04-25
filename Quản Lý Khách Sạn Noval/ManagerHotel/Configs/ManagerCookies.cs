using System;
using System.Web;

namespace ManagerHotel.Configs
{
    public class ManagerCookies
    {
        public static int GetUserIdFromCookies()
        {
            int userId = 0;
            HttpCookie userCookie = HttpContext.Current.Request.Cookies["user"];
            if (userCookie != null)
            {
                int.TryParse(userCookie.Value, out userId);
            }
            return userId;
        }

        public static void SaveUserIdInCookies(int userId)
        {
            HttpCookie userCookie = new HttpCookie("user", userId.ToString());
            //set day expires cho cookies
            userCookie.Expires = DateTime.Now.AddDays(1);
            HttpContext.Current.Response.Cookies.Add(userCookie);
        }

        public static void RemoveUserIdFromCookies()
        {
            HttpCookie userCookie = HttpContext.Current.Request.Cookies["user"];
            if (userCookie != null)
            {
                userCookie.Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Response.Cookies.Add(userCookie);
            }
        }
    }
}