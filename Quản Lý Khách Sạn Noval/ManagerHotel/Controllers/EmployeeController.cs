using ManagerHotel.Authentication;
using ManagerHotel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManagerHotel.Controllers
{
    [MyAuthorize]
    public class EmployeeController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }
        public bool ValidateEmployeeData(FormCollection collection, Employee e)
        {
            var name = collection["Name"];
            var position = collection["Position"];
            var phoneNumber = collection["PhoneNumber"];
            var email = collection["Email"];
            var address = collection["Address"];
            var hireDate = collection["HireDate"];

            if (string.IsNullOrEmpty(phoneNumber))
            {
                ModelState.AddModelError("PhoneNumber", "Số điện thoại không được để trống");
            }

            if (string.IsNullOrEmpty(name))
            {
                ModelState.AddModelError("Name", "Tên nhân viên không được để trống");
            }

            if (string.IsNullOrEmpty(position))
            {
                ModelState.AddModelError("Position", "Vị trí nhân viên không được để trống");
            }

            if (string.IsNullOrEmpty(hireDate))
            {
                ModelState.AddModelError("HireDate", "Ngày Thuê nhân viên không được để trống");
            }

            if (string.IsNullOrEmpty(email))
            {
                ModelState.AddModelError("Email", "Email nhân viên không được để trống");
            }

            if (string.IsNullOrEmpty(address))
            {
                ModelState.AddModelError("Address", "Đại chỉ nhân viên không được để trống");
            }

            DateTime hireDateValue;
            hireDateValue = DateTime.Parse(collection["HireDate"]);
                    

            if (hireDateValue == null)
            {
                ModelState.AddModelError("HireDate", "Ngày tháng không đúng định dạng.");
            }
            else
            {
                e.HireDate = hireDateValue;
            }

            return ModelState.IsValid;
        }
        public ActionResult ListEmployee()
        {
            AddUserToViewBag();
            var employees = db.Employees.ToList();
            return View(employees);
          
        }
        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            AddUserToViewBag();
            var e = db.Employees.FirstOrDefault(ro => ro.EmployeeId == id);
            return View(e);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            AddUserToViewBag();
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection collection, Employee e)
        {
            if (ModelState.IsValid)
            {
                if (!ValidateEmployeeData(collection, e))
                {
                    ViewBag.ErrorMsg = "Hãy cung cấp đúng các thông tin";
                    return View(e);
                }
               
                    db.Employees.Add(e);
                    db.SaveChanges();
                    return RedirectToAction("ListEmployee");
                
                
            }
            return this.View();
           
        }
          
        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            AddUserToViewBag();
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
                DateTime hireDate = DateTime.Parse(collection["HireDate"]);

                if (hireDate == null)
                {
                    ModelState.AddModelError("HireDate", "Ngày tháng không đúng định dạng.");
                }
                else
                {
                    e.HireDate = hireDate;
                }
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
                return this.View();
            }
        
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            AddUserToViewBag();
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
