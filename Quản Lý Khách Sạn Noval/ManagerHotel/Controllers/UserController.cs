using ManagerHotel.Authentication;
using ManagerHotel.Configs;
using ManagerHotel.Models;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ManagerHotel.Controllers
{
    
    public class UserController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(FormCollection collection, User user)
        {
            if (ModelState.IsValid)
            {
                var customer = new Customer
                {
                    FullName = collection["FullName"],
                    Email = collection["Email"],
                    PhoneNumber = collection["PhoneNumber"],
                    Address = collection["Address"],
                    IdentityCard = collection["IdentityCard"]
                };
                db.Customers.Add(customer);
                db.SaveChanges();

                user.Username = collection["Username"];
                user.Password = PasswordHasher.HashPassword(collection["Password"]);
                user.UserType = UserType.Customer;
                user.CustomerId = customer.CustomerId;

                db.Users.Add(user);
                db.SaveChanges();

                return RedirectToAction("Login", "User");
            }
            return this.View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken] // chặn dữ liệu giả mạo các mã độc
        public ActionResult Login(FormCollection collection, User user, LoginViewModel model)
        {

            var username = collection["Username"];
            var password = collection["Password"];
            if (string.IsNullOrEmpty(username) || string.IsNullOrWhiteSpace(username))
            {
                ViewData["Loi1"] = "User name không thể trống";
            }
            else if (string.IsNullOrEmpty(password) || string.IsNullOrWhiteSpace(password))
            {
                ViewData["Loi1"] = "Password không thể trống";
            }
            else
            {
                var hashPassword = PasswordHasher.HashPassword(password);
                var loginUser = db.Users.FirstOrDefault(u => u.Username == username && u.Password == hashPassword);

                if (loginUser != null)
                {
                    //FormsAuthentication.SetAuthCookie("current-user", model.RememberMe); //ts1 tên người dùng lưu trong cookies, ts2 = false khi close browser cookies sẽ bị xóa
                    //true cookies sẽ đc lưu trong vài ngày cho đến khi hết hiệu lực
                    //HttpCookie UserCookies = new HttpCookie("user",loginUser.UserId.ToString());
                    //HttpCookie UserCookies = new HttpCookie("user", loginUser.UserId.ToString());
                    //UserCookies.Expires.AddDays(10);
                    //HttpContext.Response.SetCookie(UserCookies);

                    //HttpCookie httpCookie = Request.Cookies["user"];
                    //var data = httpCookie.Value;

                    ManagerCookies.SaveUserIdInCookies(loginUser.UserId);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    //ModelState là một đối tượng trong ASP.NET MVC được sử dụng để lưu trữ và quản lý các lỗi và thông báo được tạo ra trong quá trình xử lý yêu cầu.
                    ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không hợp lệ.");//thông báo lỗi quay lại trang đăng nhập
                }
            }
            return this.Login();
        }

        public ActionResult Logout()
        {
            // Xóa cookies của người dùng
            ManagerCookies.RemoveUserIdFromCookies();
            Session.Remove("User");
            // Điều hướng về trang chủ
            return RedirectToAction("Login", "User");
        }
    }
}