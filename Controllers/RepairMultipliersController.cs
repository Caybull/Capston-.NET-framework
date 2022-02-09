using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyDynastyHomesAuth.Models;

namespace MyDynastyHomesAuth.Controllers
{
    public class RepairMultipliersController : Controller
    {
        private HouseContext db = new HouseContext();

        // GET: RepairMultipliers
        public ActionResult Index()
        {
            return View(db.RepairMultipliers.ToList());
        }

        // GET: RepairMultipliers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepairMultiplier repairMultiplier = db.RepairMultipliers.Find(id);
            if (repairMultiplier == null)
            {
                return HttpNotFound();
            }
            return View(repairMultiplier);
        }

        // GET: RepairMultipliers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RepairMultipliers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,BathroomSink,Toilet,Shower,Window,SidingPerSQFT,Roof,FoundationWall,ExteriorDoor,TreeRemoval,PaintPerRoom,DrywallPerSQFT,FloorsPerSQFT,LightFixture,Baseboards,SubfloorPerSQFT,Refrigerator,Oven,Microwave,Dishwasher,GarbageDisposal,Cabinet,CounterTopsPerSQFT,KitchenSink,FurnacePerStory,AirConditioningUnitPerStory,HotWaterHeater,Electric,Plumbing,Sewer")] RepairMultiplier repairMultiplier)
        {
            if (ModelState.IsValid)
            {
                db.RepairMultipliers.Add(repairMultiplier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(repairMultiplier);
        }

        // GET: RepairMultipliers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepairMultiplier repairMultiplier = db.RepairMultipliers.Find(id);
            if (repairMultiplier == null)
            {
                return HttpNotFound();
            }
            return View(repairMultiplier);
        }

        // POST: RepairMultipliers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,BathroomSink,Toilet,Shower,Window,SidingPerSQFT,Roof,FoundationWall,ExteriorDoor,TreeRemoval,PaintPerRoom,DrywallPerSQFT,FloorsPerSQFT,LightFixture,Baseboards,SubfloorPerSQFT,Refrigerator,Oven,Microwave,Dishwasher,GarbageDisposal,Cabinet,CounterTopsPerSQFT,KitchenSink,FurnacePerStory,AirConditioningUnitPerStory,HotWaterHeater,Electric,Plumbing,Sewer")] RepairMultiplier repairMultiplier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(repairMultiplier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(repairMultiplier);
        }

        // GET: RepairMultipliers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepairMultiplier repairMultiplier = db.RepairMultipliers.Find(id);
            if (repairMultiplier == null)
            {
                return HttpNotFound();
            }
            return View(repairMultiplier);
        }

        // POST: RepairMultipliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RepairMultiplier repairMultiplier = db.RepairMultipliers.Find(id);
            db.RepairMultipliers.Remove(repairMultiplier);
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
