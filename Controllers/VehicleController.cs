using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assignment_3_ASP.NET_MVC_CRUD.Models;

namespace Assignment_3_ASP.NET_MVC_CRUD.Controllers
{
    public class VehicleController : Controller
    {
        private db_cbsEntities db = new db_cbsEntities();

        // GET: Vehicle
        public ActionResult Index()
        {
            return View(db.tb_vehicle.ToList());
        }

        // GET: Vehicle/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_vehicle tb_vehicle = db.tb_vehicle.Find(id);
            if (tb_vehicle == null)
            {
                return HttpNotFound();
            }
            return View(tb_vehicle);
        }

        // GET: Vehicle/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vehicle/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "v_reg,v_model,v_type,v_seat,v_price")] tb_vehicle tb_vehicle)
        {
            if (ModelState.IsValid)
            {
                db.tb_vehicle.Add(tb_vehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_vehicle);
        }

        // GET: Vehicle/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_vehicle tb_vehicle = db.tb_vehicle.Find(id);
            if (tb_vehicle == null)
            {
                return HttpNotFound();
            }
            return View(tb_vehicle);
        }

        // POST: Vehicle/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "v_reg,v_model,v_type,v_seat,v_price")] tb_vehicle tb_vehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_vehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_vehicle);
        }

        // GET: Vehicle/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_vehicle tb_vehicle = db.tb_vehicle.Find(id);
            if (tb_vehicle == null)
            {
                return HttpNotFound();
            }
            return View(tb_vehicle);
        }

        // POST: Vehicle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_vehicle tb_vehicle = db.tb_vehicle.Find(id);
            db.tb_vehicle.Remove(tb_vehicle);
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
