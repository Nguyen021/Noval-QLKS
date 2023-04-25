using ManagerHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManagerHotel.Controllers
{
    public class EmployeeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ListEmployee()
        {
            var employees = db.Employees.ToList();
            return View(employees);
          
        }
        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            var e = db.Employees.FirstOrDefault(ro => ro.EmployeeId == id);
            return View(e);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection collection, Employee e)
        {
            //DateTime hireDate;
            //bool isValidDate = DateTime.TryParseExact(
            //    collection["HireDate"],
            //    "MM/dd/yyyy",
            //    CultureInfo.InvariantCulture,
            //    DateTimeStyles.None,
            //    out hireDate);

            //if (!isValidDate)
            //{
            //    ModelState.AddModelError("HireDate", "Invalid date format.");
            //}
            //else
            //{
            //    e.HireDate = hireDate;
            //}
            e.HireDate = DateTime.Parse(String.Format("{0:MM/dd/yyyy}", collection["HireDate"]));
            db.Employees.Add(e);
            db.SaveChanges();
            return RedirectToAction("ListEmployee");
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            var e = db.Employees.First(r => r.EmployeeId == id);
            return View(e);
           
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                var e = db.Employees.First(r => r.EmployeeId == id);
                e.Name = collection["Name"];
                e.Email = collection["Email"];
                e.PhoneNumber = collection["PhoneNumber"];
                e.Position = collection["Position"];
                e.HireDate = DateTime.Parse(String.Format("{0:MM/dd/yyyy}", collection["HireDate"]));
                if (decimal.TryParse(collection["Salary"], out decimal price))
                {
                    e.Salary = decimal.Round(price, 2);
                }
                e.Address = collection["Address"];
                db.SaveChanges();
                return RedirectToAction("ListEmployee");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            var e = db.Employees.First(r => r.EmployeeId == id);
            return View(e);
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var e = db.Employees.First(r => r.EmployeeId == id);
            db.Employees.Remove(e);
            db.SaveChanges();
            return RedirectToAction("ListEmployee");
        }
    }
}
