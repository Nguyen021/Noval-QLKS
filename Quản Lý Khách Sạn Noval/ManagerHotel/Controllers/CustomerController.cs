using ManagerHotel.Authentication;
using ManagerHotel.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace ManagerHotel.Controllers
{
    [MyAuthorize]
    public class CustomerController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListCustomer()
        {
            AddUserToViewBag();
            var c = db.Customers.ToList();
            return View(c);


            return View();
        }
        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            AddUserToViewBag();
            var c = db.Customers.FirstOrDefault(ro => ro.CustomerId == id);
            return View(c);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            AddUserToViewBag();
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection, Customer c)
        {
            var existingCustomer = db.Customers.FirstOrDefault(x => x.Email == c.Email);
            var existingIdentityCard = db.Customers.FirstOrDefault(x => x.IdentityCard == c.IdentityCard);
            var existingPhoneNumber = db.Customers.FirstOrDefault(x => x.PhoneNumber == c.PhoneNumber);
            if (existingCustomer != null)
            {
                ViewBag.Error = "Email đã tồn tại!";
                return View(c);
            }
            if (existingIdentityCard != null)
            {
                ViewBag.Error = "IdentityCard đã tồn tại!";
                return View(c);
            }
            if (existingPhoneNumber != null)
            {
                ViewBag.Error = "PhoneNumber đã tồn tại!";
                return View(c);
            }
            if (ModelState.IsValid)
            {
                db.Customers.Add(c);
                db.SaveChanges();
                return RedirectToAction("ListCustomer");
            }

            return View(c);
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            AddUserToViewBag();
            var c = db.Customers.First(r => r.CustomerId == id);
            return View(c);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                var c = db.Customers.First(r => r.CustomerId == id);
                c.FullName = collection["FullName"];
                c.Email = collection["Email"];
                c.PhoneNumber = collection["PhoneNumber"];
                c.Address = collection["Address"];
                c.IdentityCard = collection["IdentityCard"];

                db.SaveChanges();
                return RedirectToAction("ListCustomer");
            }
            catch(Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            AddUserToViewBag();
            var c = db.Customers.First(r => r.CustomerId == id);
            return View(c);
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var c = db.Customers.First(r => r.CustomerId == id);
                db.Customers.Remove(c);
                db.SaveChanges();
                return RedirectToAction("ListCustomer");

                  }
            catch
            {
                ViewBag.ErrorMessage = "Bạn không thế xóa Customer được tham chiếu đến bảng User. Nếu bạn vẫn muốn tiếp tục hãy xóa dữ liệu liên quan và quay lại sau";
               
                return View();
            }
          
        }
    }
}
