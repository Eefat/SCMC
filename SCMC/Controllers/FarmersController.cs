using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SCMS.DAL;
using SCMS.Models;
using PagedList;

namespace SCMC.Controllers
{
    public class FarmersController : Controller
    {
        private SCMSContext db = new SCMSContext();

        // GET: Farmers
        //public ActionResult Index()
        //{
        //    return View(db.Farmers.ToList());
        //}
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {

            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;
            var farmers = from s in db.Farmers
                          select s;
            if (!String.IsNullOrEmpty(searchString)) { farmers = farmers.Where(s => s.FirsName.ToUpper().Contains(searchString.ToUpper()) || s.LastName.ToUpper().Contains(searchString.ToUpper())); }
            switch (sortOrder)
            {
                case "name_desc":
                    farmers = farmers.OrderByDescending(s => s.FirsName);
                    break;
                case "Date":
                    farmers = farmers.OrderBy(s => s.DateOfBirth);
                    break;
                case "date_desc":
                    farmers = farmers.OrderByDescending(s => s.DateOfBirth);
                    break;
                default:
                    farmers = farmers.OrderBy(s => s.FirsName);
                    break;
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(farmers.ToPagedList(pageNumber, pageSize));
        }

        // GET: Farmers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Farmer farmer = db.Farmers.Find(id);
            if (farmer == null)
            {
                return HttpNotFound();
            }
            return View(farmer);
        }

        // GET: Farmers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Farmers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirsName,MiddleName,LastName,Address,NationalIdNo,DateOfBirth")] Farmer farmer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Farmers.Add(farmer);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(farmer);
        }

        // GET: Farmers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Farmer farmer = db.Farmers.Find(id);
            if (farmer == null)
            {
                return HttpNotFound();
            }
            return View(farmer);
        }

        // POST: Farmers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirsName,MiddleName,LastName,Address,NationalIdNo,DateOfBirth")] Farmer farmer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(farmer).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(farmer);
        }

        // GET: Farmers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Farmer farmer = db.Farmers.Find(id);
            if (farmer == null)
            {
                return HttpNotFound();
            }
            return View(farmer);
        }

        // POST: Farmers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Farmer farmer = db.Farmers.Find(id);
            db.Farmers.Remove(farmer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
