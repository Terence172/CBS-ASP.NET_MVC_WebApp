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
    public class BookingController : Controller
    {
        private db_cbsEntities db = new db_cbsEntities();

        // GET: Booking
        public ActionResult Index()
        {
            var tb_booking = db.tb_booking.Include(t => t.tb_vehicle).Include(t => t.tb_user);
            return View(tb_booking.ToList());
        }

        // GET: Booking/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_booking tb_booking = db.tb_booking.Find(id);
            if (tb_booking == null)
            {
                return HttpNotFound();
            }
            return View(tb_booking);
        }

        // GET: Booking/Create
        public ActionResult Create()
        {
            ViewBag.b_vehicle = new SelectList(db.tb_vehicle, "v_reg", "v_model");
            ViewBag.b_customer = new SelectList(db.tb_user, "u_ic", "u_pass");
            return View();
        }

        // POST: Booking/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "b_id,b_bdate,b_rdate,b_total,b_status,b_customer,b_vehicle")] tb_booking tb_booking)
        {
            if (ModelState.IsValid)
            {
                db.tb_booking.Add(tb_booking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.b_vehicle = new SelectList(db.tb_vehicle, "v_reg", "v_model", tb_booking.b_vehicle);
            ViewBag.b_customer = new SelectList(db.tb_user, "u_ic", "u_pass", tb_booking.b_customer);
            return View(tb_booking);
        }

        // GET: Booking/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_booking tb_booking = db.tb_booking.Find(id);
            if (tb_booking == null)
            {
                return HttpNotFound();
            }
            ViewBag.b_vehicle = new SelectList(db.tb_vehicle, "v_reg", "v_model", tb_booking.b_vehicle);
            ViewBag.b_customer = new SelectList(db.tb_user, "u_ic", "u_pass", tb_booking.b_customer);
            return View(tb_booking);
        }

        // POST: Booking/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "b_id,b_bdate,b_rdate,b_total,b_status,b_customer,b_vehicle")] tb_booking tb_booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.b_vehicle = new SelectList(db.tb_vehicle, "v_reg", "v_model", tb_booking.b_vehicle);
            ViewBag.b_customer = new SelectList(db.tb_user, "u_ic", "u_pass", tb_booking.b_customer);
            return View(tb_booking);
        }

        // GET: Booking/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_booking tb_booking = db.tb_booking.Find(id);
            if (tb_booking == null)
            {
                return HttpNotFound();
            }
            return View(tb_booking);
        }

        // POST: Booking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_booking tb_booking = db.tb_booking.Find(id);
            db.tb_booking.Remove(tb_booking);
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
