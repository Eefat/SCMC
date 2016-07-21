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
    public class CunltivationDetailsController : Controller
    {
        private SCMSContext db = new SCMSContext();

        // GET: CunltivationDetails
        //public ActionResult Index()
        //{
        //    var cunltivationDetails = db.CunltivationDetails.Include(c => c.Farmer);
        //    return View(cunltivationDetails.ToList());
        //}
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, DateTime? deliverDate, DateTime? dateOfPlanting, int? page)
        {

            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            if (searchString != null || dateOfPlanting !=null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;
            var cultivationDetails = from s in db.CunltivationDetails
                          select s;
            if (!String.IsNullOrEmpty(searchString)) { cultivationDetails = cultivationDetails.Where(s => s.Farmer.FirsName.ToUpper().Contains(searchString.ToUpper()) || s.Farmer.FirsName.ToUpper().Contains(searchString.ToUpper())); }
            if (dateOfPlanting != null) { cultivationDetails = cultivationDetails.Where(s => s.DateofPlanting == dateOfPlanting); }
            if (deliverDate != null) { cultivationDetails = cultivationDetails.Where(s => s.DeliverDate == deliverDate); }
            switch (sortOrder)
            {
                case "name_desc":
                    cultivationDetails = cultivationDetails.OrderByDescending(s => s.Farmer.FirsName);
                    break;
                case "Date":
                    cultivationDetails = cultivationDetails.OrderBy(s => s.Farmer.DateOfBirth);
                    break;
                case "date_desc":
                    cultivationDetails = cultivationDetails.OrderByDescending(s => s.Farmer.DateOfBirth);
                    break;
                default:
                    cultivationDetails = cultivationDetails.OrderBy(s => s.Farmer.FirsName);
                    break;
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(cultivationDetails.ToPagedList(pageNumber, pageSize));
        }
        // GET: CunltivationDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CunltivationDetail cunltivationDetail = db.CunltivationDetails.Find(id);
            if (cunltivationDetail == null)
            {
                return HttpNotFound();
            }
            return View(cunltivationDetail);
        }

        // GET: CunltivationDetails/Create
        public ActionResult Create()
        {
            ViewBag.FarmerId = new SelectList(db.Farmers, "ID", "FirsName");
            return View();
        }

        // POST: CunltivationDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FarmerId,LandArea,CaneVariety,PlantRatoon,DateofPlanting,EstimatedTime,DeliverDate")] CunltivationDetail cunltivationDetail)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.CunltivationDetails.Add(cunltivationDetail);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.FarmerId = new SelectList(db.Farmers, "ID", "FirsName", cunltivationDetail.FarmerId);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(cunltivationDetail);
        }

        // GET: CunltivationDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CunltivationDetail cunltivationDetail = db.CunltivationDetails.Find(id);
            if (cunltivationDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.FarmerId = new SelectList(db.Farmers, "ID", "FirsName", cunltivationDetail.FarmerId);
            return View(cunltivationDetail);
        }

        // POST: CunltivationDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FarmerId,LandArea,CaneVariety,PlantRatoon,DateofPlanting,EstimatedTime,DeliverDate")] CunltivationDetail cunltivationDetail)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(cunltivationDetail).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.FarmerId = new SelectList(db.Farmers, "ID", "FirsName", cunltivationDetail.FarmerId);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to update. Try again, and if the problem persists see your system administrator.");
            }
            return View(cunltivationDetail);
        }

        // GET: CunltivationDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CunltivationDetail cunltivationDetail = db.CunltivationDetails.Find(id);
            if (cunltivationDetail == null)
            {
                return HttpNotFound();
            }
            return View(cunltivationDetail);
        }

        // POST: CunltivationDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                CunltivationDetail cunltivationDetail = db.CunltivationDetails.Find(id);
                db.CunltivationDetails.Remove(cunltivationDetail);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to delete. Try again, and if the problem persists see your system administrator.");
            }
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
