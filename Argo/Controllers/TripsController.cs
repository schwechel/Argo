using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Argo.Models;

namespace Argo.Controllers
{
    public class TripsController : Controller
    {
        private ArgoContext db = new ArgoContext();

        // GET: Trips
        public ActionResult Index()
        {
            return View(db.Trips.Include(x => x.Bus).Take(3).ToList());
        }

        // GET: Trips/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trip trip = db.Trips.Include(x => x.Bus).Where(x => x.Id == id).FirstOrDefault();
            if (trip == null)
            {
                return HttpNotFound();
            }
            return View(trip);
        }

        // GET: Trips/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Trips/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Departure,Destination,DepartTime,ReturnTime,Event,EventDescription,IsPrivate")] Trip trip, FormCollection frm)
        {
            if (ModelState.IsValid)
            {
                Bus b = new Bus();

                b.NumberOfSeats = int.Parse(frm["rgNumberSeats"]);

                b.Price = 200 + trip.ReturnTime.Subtract(trip.DepartTime).TotalHours * 60; //$200 flat fee + $60 per hour (or $1 per minute)

                b.SeatsAvailable = b.NumberOfSeats - 1;
                db.Buses.Add(b);
                db.SaveChanges();

                trip.Busid = b.Id;
                trip.Type = int.Parse(frm["rgType"]);
                db.Trips.Add(trip);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trip);
        }

        // GET: Trips/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trip trip = db.Trips.Find(id);
            if (trip == null)
            {
                return HttpNotFound();
            }
            return View(trip);
        }

        // POST: Trips/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Departure,Destination,DepartTime,ReturnTime,Type,Event,EventDescription,IsPrivate")] Trip trip)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trip).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trip);
        }

        public ActionResult Confirm(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trip trip = db.Trips.Include(x => x.Bus).Where(x => x.Id == id).FirstOrDefault();
            if (trip == null)
            {
                return HttpNotFound();
            }
            trip.Bus.SeatsAvailable -= 1;
            db.SaveChanges();
            return View(trip);
        }

        // GET: Trips/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trip trip = db.Trips.Find(id);
            if (trip == null)
            {
                return HttpNotFound();
            }
            return View(trip);
        }

        // POST: Trips/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trip trip = db.Trips.Find(id);
            db.Trips.Remove(trip);
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
