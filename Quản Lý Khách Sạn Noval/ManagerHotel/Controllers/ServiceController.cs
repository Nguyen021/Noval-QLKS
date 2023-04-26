using ManagerHotel.Authentication;
using ManagerHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManagerHotel.Controllers
{
    [MyAuthorize]
    public class ServiceController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Service
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ListService()
        {
            AddUserToViewBag();
            var services = db.Services.ToList();
            return View(services);
        }
        // GET: Service/Details/5
        public ActionResult Details(int id)
        {
            AddUserToViewBag();
            var s = db.Services.Where(sv => sv.ServiceId == id).FirstOrDefault();
            var r2 = db.Services.FirstOrDefault(sv => sv.ServiceId == id);
            return View(s);
           
        }

        // GET: Service/Create
        public ActionResult Create()
        {
            AddUserToViewBag();
            //var svTypeIds = db.ServiceTypes.Select(r => r.ServiceTypeId).ToList();
            //ViewBag.ServiceTypeIds = svTypeIds;

            ViewBag.ServiceTypeList = new SelectList(db.ServiceTypes, "ServiceTypeId", "Name");

            return View();
        }

        // POST: Service/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection collection, Service service)
        {
             var TenService = collection["Name"];
             var PriceService = collection["Price"];

            if (string.IsNullOrEmpty(TenService))
            {
                ViewData["LoiTenService"] = "Tên Service không được để trống";
            }
            else if (string.IsNullOrEmpty(PriceService))
            {
                ViewData["LoiGiaService"] = "Giá Service không được để trống";
            }
            
            db.Services.Add(service);
            db.SaveChanges();
            return RedirectToAction("ListService");
        }

        // GET: Service/Edit/5
        public ActionResult Edit(int id)
        {
            AddUserToViewBag();
            var service = db.Services.First(s => s.ServiceId == id);

            ViewBag.ServiceTypeList = new SelectList(db.ServiceTypes, "ServiceTypeId", "Name");
            return View(service);
        }

        // POST: Service/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var sv = db.Services.First(s => s.ServiceId == id);
            sv.Name = collection["Name"];
            sv.Description = collection["Description"];
            //sv.Price = decimal.Parse(collection["Price"]);
            if (decimal.TryParse(collection["Price"], out decimal price))
            {
                sv.Price = decimal.Round(price, 2);
            }
         
            sv.IsAvailable = collection["IsAvailable"];
            sv.ServiceTypeId = int.Parse(collection["ServiceTypeId"]);

            db.SaveChanges();
            return RedirectToAction("ListService");
        }

        // GET: Service/Delete/5
        public ActionResult Delete(int id)
        {
            AddUserToViewBag();
            var service = db.Services.First(s => s.ServiceId == id);
            return View(service);
        }

      
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var sv = db.Services.First(r => r.ServiceId == id);
            db.Services.Remove(sv);
            db.SaveChanges();
            return RedirectToAction("ListService");
        }
    }
}
