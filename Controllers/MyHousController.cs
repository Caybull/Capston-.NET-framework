using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyDynastyHomesAuth.Models;
using MyDynastyHomesAuth;
using Microsoft.AspNet.Identity;

namespace MyDynastyHomesAuth.Controllers
{
    [Authorize]
    public class MyHousController : Controller
    {

        private HouseContext db = new HouseContext();

        // GET: MyHous
        public ActionResult Index()
        {
            AspNetUser aspNetUser = db.AspNetUsers.Find(User.Identity.GetUserId());


            var myHouses = db.MyHouses.Where(x => x.UserId == aspNetUser.Id)
                .Include(m => m.AspNetUser).Include(m => m.Bathroom).Include(m => m.Exterior).Include(m => m.Interior).Include(m => m.Kitchen).Include(m => m.Utility);
            foreach (MyHous myHous in myHouses)
            {
                myHous.RenovationCost = (decimal)(myHous.BathroomCost + myHous.ExteriorCost + myHous.InteriorCost + myHous.KitchenCost + myHous.UtilitiesCost);

            }
            //db.SaveChanges();

            return View(myHouses.ToList());
        }

        public ActionResult MyHousDetailsOne(int? id)
        {
            AspNetUser aspNetUser = db.AspNetUsers.Find(User.Identity.GetUserId());

            var myHouses = db.MyHouses.Where(x => x.UserId == aspNetUser.Id)
               .Include(m => m.AspNetUser).Include(m => m.Bathroom).Include(m => m.Exterior).Include(m => m.Interior).Include(m => m.Kitchen).Include(m => m.Utility);
            foreach(MyHous house in myHouses)
            {
                if(house.ID == id)
                {
                    MyHous myHous = house;
                    myHous.RenovationCost = (int)(myHous.BathroomCost + myHous.ExteriorCost + myHous.InteriorCost + myHous.KitchenCost + myHous.UtilitiesCost);


                    //db.SaveChanges();

                    return View(myHous);


                }
            }
            return View();
          
        }

        public ActionResult BathroomDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bathroom bathroom = db.Bathrooms.Find(id);
            if (bathroom == null)
            {
                return HttpNotFound();
            }
            return View(bathroom);
        }

        public ActionResult ExteriorDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exterior exterior = db.Exteriors.Find(id);
            if (exterior == null)
            {
                return HttpNotFound();
            }
            return View(exterior);
        }

        public ActionResult InteriorDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Interior interior = db.Interiors.Find(id);
            if (interior == null)
            {
                return HttpNotFound();
            }
            return View(interior);
        }

        public ActionResult KitchenDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kitchen kitchen = db.Kitchens.Find(id);
            if (kitchen == null)
            {
                return HttpNotFound();
            }
            return View(kitchen);
        }

        public ActionResult UtilityDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utility utility = db.Utilities.Find(id);
            if (utility == null)
            {
                return HttpNotFound();
            }
            return View(utility);
        }


        public ActionResult BathroomsCost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyHous myHous = db.MyHouses.Find(id);
            Bathroom bathroom = myHous.Bathroom;
            if (myHous == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = new SelectList(db.MyHouses, "ID", "StreetNumber");
            ViewBag.MultiplierID = new SelectList(db.RepairMultipliers, "ID", "ID");
            return View(bathroom);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BathroomsCost([Bind(Include = "ID,Number_Of_Sinks,Number_Of_Toilets,Number_Of_Showers")] Bathroom bathroom)
        {
            int id = 1;

            RepairMultiplier repairMultiplier = db.RepairMultipliers.Find(id);

            foreach (MyHous myHous in db.MyHouses)
            {
                if (bathroom.ID.Equals(myHous.ID))
                {
                    myHous.Bathroom = bathroom;
                    bathroom.RepairCost = (int)((bathroom.Number_Of_Sinks * repairMultiplier.BathroomSink) + (bathroom.Number_Of_Toilets * repairMultiplier.Toilet) + (bathroom.Number_Of_Showers * repairMultiplier.Shower));
                    db.Bathrooms.Add(bathroom);
                    myHous.BathroomCost = bathroom.RepairCost;

                }

            }
            db.SaveChanges();
            return RedirectToAction("Index");
            ViewBag.ID = new SelectList(db.MyHouses, "ID", "StreetNumber", bathroom.ID);
           // ViewBag.MultiplierID = new SelectList(db.RepairMultipliers, "ID", "ID", bathroom.MultiplierID);
            return View(bathroom);
        }

        public ActionResult ExteriorCost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyHous myHous = db.MyHouses.Find(id);
            Exterior exterior = myHous.Exterior;
            if (myHous == null)
            {
                return HttpNotFound();
            }

            ViewBag.ID = new SelectList(db.MyHouses, "ID", "StreetNumber");
            ViewBag.MultiplierID = new SelectList(db.RepairMultipliers, "ID", "ID");
            return View(exterior);
        }

        // POST: Exteriors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ExteriorCost([Bind(Include = "ID,C_Windows,Siding_SQFT,Roof_SQFT,Number_Of_Foundation_Walls,Number_Of_Doors,Number_Of_Trees,MultiplierID")] Exterior exterior)
        {
            int id = 1;
          //  id = exterior.MultiplierID;
            RepairMultiplier repairMultiplier = db.RepairMultipliers.Find(id);

            foreach (MyHous myHous in db.MyHouses)
            {
                if (exterior.ID.Equals(myHous.ID))
                {
                    myHous.Exterior = exterior;
                    exterior.RepairCost = (int)((exterior.C_Windows * repairMultiplier.Window) + (exterior.Siding_SQFT * repairMultiplier.SidingPerSQFT) + (exterior.Roof_SQFT * repairMultiplier.Roof) + (exterior.Number_Of_Foundation_Walls * repairMultiplier.FoundationWall) + (exterior.Number_Of_Doors * repairMultiplier.ExteriorDoor) +
                        (exterior.Number_Of_Trees * repairMultiplier.TreeRemoval));
                    db.Exteriors.Add(exterior);
                    myHous.ExteriorCost = exterior.RepairCost;
                }

            }
            db.SaveChanges();
            return RedirectToAction("Index");
            ViewBag.ID = new SelectList(db.MyHouses, "ID", "StreetNumber", exterior.ID);
           // ViewBag.MultiplierID = new SelectList(db.RepairMultipliers, "ID", "ID", exterior.MultiplierID);
            return View(exterior);
        }

        public ActionResult InteriorCost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyHous myHous = db.MyHouses.Find(id);
            Interior interior = myHous.Interior;
            if (myHous == null)
            {
                return HttpNotFound();
            }

            ViewBag.ID = new SelectList(db.MyHouses, "ID", "StreetNumber");
            ViewBag.MultiplierID = new SelectList(db.RepairMultipliers, "ID", "ID");
            return View(interior);

        }

        // POST: Interiors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InteriorCost([Bind(Include = "ID,Paint_Number_Of_Rooms,Drywall_SQFT,Floors_SQFT,Number_Of_Light_Fixtures,Baseboard_Linear_Foot,Subfloor_SQFT,MultiplierID")] Interior interior)
        {
            int id = 1;
           // id = interior.MultiplierID;
            RepairMultiplier repairMultiplier = db.RepairMultipliers.Find(id);

            foreach (MyHous myHous in db.MyHouses)
            {
                if (interior.ID.Equals(myHous.ID))
                {
                    myHous.Interior = interior;
                    interior.RepairCost = (int)((interior.Paint_Number_Of_Rooms * repairMultiplier.PaintPerRoom) + (interior.Drywall_SQFT * repairMultiplier.DrywallPerSQFT) + (interior.Floors_SQFT * repairMultiplier.FloorsPerSQFT) + (interior.Number_Of_Light_Fixtures * repairMultiplier.LightFixture)
                        + (interior.Baseboard_Linear_Foot * repairMultiplier.Baseboards) + (interior.Subfloor_SQFT * repairMultiplier.SubfloorPerSQFT));

                    db.Interiors.Add(interior);
                    myHous.InteriorCost = interior.RepairCost;
                }

            }
            db.SaveChanges();
            return RedirectToAction("Index");


            ViewBag.ID = new SelectList(db.MyHouses, "ID", "StreetNumber", interior.ID);
           // ViewBag.MultiplierID = new SelectList(db.RepairMultipliers, "ID", "ID", interior.MultiplierID);
            return View(interior);
        }

        public ActionResult KitchenCost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyHous myHous = db.MyHouses.Find(id);
            Kitchen kitchen = myHous.Kitchen;
            if (myHous == null)
            {
                return HttpNotFound();
            }

            ViewBag.ID = new SelectList(db.MyHouses, "ID", "StreetNumber");
            ViewBag.MultiplierID = new SelectList(db.RepairMultipliers, "ID", "ID");
            return View(kitchen);

        }

        // POST: Kitchens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult KitchenCost([Bind(Include = "ID,Refrigerator,Oven,Microwave,Dishwasher,Garbage_Disposal,Cabinets,Counter_Tops_SQFT,Sink,MultiplierID")] Kitchen kitchen)
        {
            int id = 1;
         //   id = kitchen.MultiplierID;
            RepairMultiplier repairMultiplier = db.RepairMultipliers.Find(id);

            foreach (MyHous myHous in db.MyHouses)
            {
                if (kitchen.ID.Equals(myHous.ID))
                {
                    myHous.Kitchen = kitchen;
                    kitchen.RepairCost = (int)((kitchen.Refrigerator * repairMultiplier.Refrigerator) + (kitchen.Oven * repairMultiplier.Oven) + (kitchen.Microwave * repairMultiplier.Microwave) + (kitchen.Dishwasher * repairMultiplier.Dishwasher)
                        + (kitchen.Garbage_Disposal * repairMultiplier.GarbageDisposal) + (kitchen.Cabinets * repairMultiplier.Cabinet) + (kitchen.Counter_Tops_SQFT * repairMultiplier.CounterTopsPerSQFT) +
                        (kitchen.Sink * repairMultiplier.KitchenSink));

                    db.Kitchens.Add(kitchen);
                    myHous.KitchenCost = kitchen.RepairCost;
                }

            }
            db.SaveChanges();
            return RedirectToAction("Index");


            ViewBag.ID = new SelectList(db.MyHouses, "ID", "StreetNumber", kitchen.ID);
         //   ViewBag.MultiplierID = new SelectList(db.RepairMultipliers, "ID", "ID", kitchen.MultiplierID);
            return View(kitchen);
        }

        public ActionResult UtilitiesCost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyHous myHous = db.MyHouses.Find(id);
            Utility utility = myHous.Utility;
            if (myHous == null)
            {
                return HttpNotFound();
            }

            ViewBag.ID = new SelectList(db.MyHouses, "ID", "StreetNumber");
            ViewBag.MultiplierID = new SelectList(db.RepairMultipliers, "ID", "ID");
            return View(utility);

        }

        // POST: Utilities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UtilitiesCost([Bind(Include = "ID,Furnaces,AirConditioning_Units,Hot_Water_Heater,Electric,Plumbing,Sewer,MultiplierID")] Utility utility)
        {

            int id = 1;
         //   id = utility.MultiplierID;
            RepairMultiplier repairMultiplier = db.RepairMultipliers.Find(id);

            foreach (MyHous myHous in db.MyHouses)
            {
                if (utility.ID.Equals(myHous.ID))
                {
                    myHous.Utility = utility;
                    utility.RepairCost = (int)((utility.Furnaces * repairMultiplier.FurnacePerStory) + (utility.AirConditioning_Units * repairMultiplier.AirConditioningUnitPerStory) + (utility.Hot_Water_Heater * repairMultiplier.HotWaterHeater) +
                        (utility.Electric * repairMultiplier.Electric) + (utility.Plumbing * repairMultiplier.Plumbing) + (utility.Sewer * repairMultiplier.Sewer));

                    db.Utilities.Add(utility);
                    myHous.UtilitiesCost = utility.RepairCost;
                }

            }
            db.SaveChanges();
            return RedirectToAction("Index");


            ViewBag.ID = new SelectList(db.MyHouses, "ID", "StreetNumber", utility.ID);
          //  ViewBag.MultiplierID = new SelectList(db.RepairMultipliers, "ID", "ID", utility.MultiplierID);
            return View(utility);
        }

        public ActionResult EditBathroom(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bathroom bathroom = db.Bathrooms.Find(id);
            if (bathroom == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = new SelectList(db.MyHouses, "ID", "StreetNumber", bathroom.ID);
       //     ViewBag.MultiplierID = new SelectList(db.RepairMultipliers, "ID", "ID", bathroom.MultiplierID);
            return View(bathroom);
        }

        // POST: Bathrooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditBathroom([Bind(Include = "ID,Number_Of_Sinks,Number_Of_Toilets,Number_Of_Showers")] Bathroom bathroom)
        {
            int id = 1;
            RepairMultiplier repairMultiplier = db.RepairMultipliers.Find(id);

            if (ModelState.IsValid)
            {
                bathroom.RepairCost = (int)((bathroom.Number_Of_Sinks * repairMultiplier.BathroomSink) + (bathroom.Number_Of_Toilets * repairMultiplier.Toilet) + (bathroom.Number_Of_Showers * repairMultiplier.Shower));
                db.Bathrooms.Add(bathroom);

                MyHous myHous = db.MyHouses.Find(bathroom.ID);
                myHous.Bathroom = bathroom;
                myHous.BathroomCost = bathroom.RepairCost;


                db.Entry(bathroom).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.MyHouses, "ID", "StreetNumber", bathroom.ID);
          //  ViewBag.MultiplierID = new SelectList(db.RepairMultipliers, "ID", "ID", bathroom.MultiplierID);
            return View(bathroom);
        }


        public ActionResult EditExterior(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exterior exterior = db.Exteriors.Find(id);
            if (exterior == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = new SelectList(db.MyHouses, "ID", "StreetNumber", exterior.ID);
        //    ViewBag.MultiplierID = new SelectList(db.RepairMultipliers, "ID", "ID", exterior.MultiplierID);
            return View(exterior);
        }

        // POST: Exteriors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditExterior([Bind(Include = "ID,C_Windows,Siding_SQFT,Roof_SQFT,Number_Of_Foundation_Walls,Number_Of_Doors,Number_Of_Trees")] Exterior exterior)
        {
            int id = 1;
            RepairMultiplier repairMultiplier = db.RepairMultipliers.Find(id);

            if (ModelState.IsValid)
            {
                exterior.RepairCost = (int)((exterior.C_Windows * repairMultiplier.Window) + (exterior.Siding_SQFT * repairMultiplier.SidingPerSQFT) + (1 * repairMultiplier.Roof) + (exterior.Number_Of_Foundation_Walls * repairMultiplier.FoundationWall) + (exterior.Number_Of_Doors * repairMultiplier.ExteriorDoor) +
                       (exterior.Number_Of_Trees * repairMultiplier.TreeRemoval));
                db.Exteriors.Add(exterior);

                MyHous myHous = db.MyHouses.Find(exterior.ID);
                myHous.Exterior = exterior;
                myHous.ExteriorCost = exterior.RepairCost;

                db.Entry(exterior).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.MyHouses, "ID", "StreetNumber", exterior.ID);
          //  ViewBag.MultiplierID = new SelectList(db.RepairMultipliers, "ID", "ID", exterior.MultiplierID);
            return View(exterior);
        }


        public ActionResult EditInterior(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Interior interior = db.Interiors.Find(id);
            if (interior == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = new SelectList(db.MyHouses, "ID", "StreetNumber", interior.ID);
          //  ViewBag.MultiplierID = new SelectList(db.RepairMultipliers, "ID", "ID", interior.MultiplierID);
            return View(interior);
        }

        // POST: Interiors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditInterior([Bind(Include = "ID,Paint_Number_Of_Rooms,Drywall_SQFT,Floors_SQFT,Number_Of_Light_Fixtures,Baseboard_Linear_Foot,Subfloor_SQFT")] Interior interior)
        {
            int id = 1;
            RepairMultiplier repairMultiplier = db.RepairMultipliers.Find(id);

            if (ModelState.IsValid)
            {

                interior.RepairCost = (int)((interior.Paint_Number_Of_Rooms * repairMultiplier.PaintPerRoom) + (interior.Drywall_SQFT * repairMultiplier.DrywallPerSQFT) + (interior.Floors_SQFT * repairMultiplier.FloorsPerSQFT) + (interior.Number_Of_Light_Fixtures * repairMultiplier.LightFixture)
                       + (interior.Baseboard_Linear_Foot * repairMultiplier.Baseboards) + (interior.Subfloor_SQFT * repairMultiplier.SubfloorPerSQFT));

                db.Interiors.Add(interior);

                MyHous myHous = db.MyHouses.Find(interior.ID);
                myHous.Interior = interior;
                myHous.InteriorCost = interior.RepairCost;

                db.Entry(interior).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.MyHouses, "ID", "StreetNumber", interior.ID);
          //  ViewBag.MultiplierID = new SelectList(db.RepairMultipliers, "ID", "ID", interior.MultiplierID);
            return View(interior);
        }


        public ActionResult EditKitchen(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kitchen kitchen = db.Kitchens.Find(id);
            if (kitchen == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = new SelectList(db.MyHouses, "ID", "StreetNumber", kitchen.ID);
         //   ViewBag.MultiplierID = new SelectList(db.RepairMultipliers, "ID", "ID", kitchen.MultiplierID);
            return View(kitchen);
        }

        // POST: Kitchens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditKitchen([Bind(Include = "ID,Refrigerator,Oven,Microwave,Dishwasher,Garbage_Disposal,Cabinets,Counter_Tops_SQFT,Sink")] Kitchen kitchen)
        {
            int id = 1;
            RepairMultiplier repairMultiplier = db.RepairMultipliers.Find(id);

            if (ModelState.IsValid)
            {


                kitchen.RepairCost = (int)((kitchen.Refrigerator * repairMultiplier.Refrigerator) + (kitchen.Oven * repairMultiplier.Oven) + (kitchen.Microwave * repairMultiplier.Microwave) + (kitchen.Dishwasher * repairMultiplier.Dishwasher)
                    + (kitchen.Garbage_Disposal * repairMultiplier.GarbageDisposal) + (kitchen.Cabinets * repairMultiplier.Cabinet) + (kitchen.Counter_Tops_SQFT * repairMultiplier.CounterTopsPerSQFT) +
                    (kitchen.Sink * repairMultiplier.KitchenSink));

                db.Kitchens.Add(kitchen);

                MyHous myHous = db.MyHouses.Find(kitchen.ID);
                myHous.Kitchen = kitchen;
                myHous.KitchenCost = kitchen.RepairCost;


                db.Entry(kitchen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.MyHouses, "ID", "StreetNumber", kitchen.ID);
          //  ViewBag.MultiplierID = new SelectList(db.RepairMultipliers, "ID", "ID", kitchen.MultiplierID);
            return View(kitchen);
        }

        public ActionResult EditUtility(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utility utility = db.Utilities.Find(id);
            if (utility == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = new SelectList(db.MyHouses, "ID", "StreetNumber", utility.ID);
        //    ViewBag.MultiplierID = new SelectList(db.RepairMultipliers, "ID", "ID", utility.MultiplierID);
            return View(utility);
        }

        // POST: Utilities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUtility([Bind(Include = "ID,Furnaces,AirConditioning_Units,Hot_Water_Heater,Electric,Plumbing,Sewer")] Utility utility)
        {
            int id = 1;
            RepairMultiplier repairMultiplier = db.RepairMultipliers.Find(id);


            if (ModelState.IsValid)
            {

                utility.RepairCost = (int)((utility.Furnaces * repairMultiplier.FurnacePerStory) + (utility.AirConditioning_Units * repairMultiplier.AirConditioningUnitPerStory) + (utility.Hot_Water_Heater * repairMultiplier.HotWaterHeater) +
                    (utility.Electric * repairMultiplier.Electric) + (utility.Plumbing * repairMultiplier.Plumbing) + (utility.Sewer * repairMultiplier.Sewer));

                db.Utilities.Add(utility);

                MyHous myHous = db.MyHouses.Find(utility.ID);
                myHous.Utility = utility;
                myHous.UtilitiesCost = utility.RepairCost;



                db.Entry(utility).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.MyHouses, "ID", "StreetNumber", utility.ID);
        //    ViewBag.MultiplierID = new SelectList(db.RepairMultipliers, "ID", "ID", utility.MultiplierID);
            return View(utility);
        }

        public ActionResult DeleteBathroom(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bathroom bathroom = db.Bathrooms.Find(id);
            if (bathroom == null)
            {
                return HttpNotFound();
            }
            return View(bathroom);
        }

        // POST: Bathrooms/Delete/5
        [HttpPost, ActionName("DeleteBathroom")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteBathroomConfirmed(int id)
        {
            MyHous myHous = db.MyHouses.Find(id);
            myHous.BathroomCost = 0;
            Bathroom bathroom = db.Bathrooms.Find(id);
            db.Bathrooms.Remove(bathroom);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteExterior(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exterior exterior = db.Exteriors.Find(id);
            if (exterior == null)
            {
                return HttpNotFound();
            }
            return View(exterior);
        }

        // POST: Exteriors/Delete/5
        [HttpPost, ActionName("DeleteExterior")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteExteriorConfirmed(int id)
        {

            MyHous myHous = db.MyHouses.Find(id);
            myHous.ExteriorCost = 0;
            Exterior exterior = db.Exteriors.Find(id);
            db.Exteriors.Remove(exterior);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteInterior(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Interior interior = db.Interiors.Find(id);
            if (interior == null)
            {
                return HttpNotFound();
            }
            return View(interior);
        }

        // POST: Interiors/Delete/5
        [HttpPost, ActionName("DeleteInterior")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteInteriorConfirmed(int id)
        {

            MyHous myHous = db.MyHouses.Find(id);
            myHous.InteriorCost = 0;
            Interior interior = db.Interiors.Find(id);
            db.Interiors.Remove(interior);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteKitchen(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kitchen kitchen = db.Kitchens.Find(id);
            if (kitchen == null)
            {
                return HttpNotFound();
            }
            return View(kitchen);
        }

        // POST: Kitchens/Delete/5
        [HttpPost, ActionName("DeleteKitchen")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteKitchenConfirmed(int id)
        {
            MyHous myHous = db.MyHouses.Find(id);
            myHous.KitchenCost = 0;
            Kitchen kitchen = db.Kitchens.Find(id);
            db.Kitchens.Remove(kitchen);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteUtility(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utility utility = db.Utilities.Find(id);
            if (utility == null)
            {
                return HttpNotFound();
            }
            return View(utility);
        }

        // POST: Utilities/Delete/5
        [HttpPost, ActionName("DeleteUtility")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteUtilityConfirmed(int id)
        {
            MyHous myHous = db.MyHouses.Find(id);
            myHous.UtilitiesCost = 0;
            Utility utility = db.Utilities.Find(id);
            db.Utilities.Remove(utility);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        // GET: MyHous/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyHous myHous = db.MyHouses.Find(id);
            if (myHous == null)
            {
                return HttpNotFound();
            }
            return View(myHous);
        }

        // GET: MyHous/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.ID = new SelectList(db.Bathrooms, "ID", "ID");
            ViewBag.ID = new SelectList(db.Exteriors, "ID", "ID");
            ViewBag.ID = new SelectList(db.Interiors, "ID", "ID");
            ViewBag.ID = new SelectList(db.Kitchens, "ID", "ID");
            ViewBag.ID = new SelectList(db.Utilities, "ID", "ID");
            return View();
        }

        // POST: MyHous/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StreetNumber,StreetName,City,LotSize,SquareFootage,Stories,BedroomCount,BathroomCount,RoomCount,RenovationCost,BathroomCost,ExteriorCost,InteriorCost,KitchenCost,UtilitiesCost,UserId")] MyHous myHous)
        {


            foreach (AspNetUser auser in db.AspNetUsers)
            {
                if (auser.Id.Equals(myHous.UserId))
                {
                    if(myHous.BathroomCost == null)
                    {
                        myHous.BathroomCost = 0;
                    }
                    if(myHous.ExteriorCost == null)
                    {
                        myHous.ExteriorCost = 0;
                    }
                  if(myHous.InteriorCost == null)
                    {
                        myHous.InteriorCost = 0;
                    }
                   if(myHous.KitchenCost == null)
                    {
                        myHous.KitchenCost = 0;
                    }
                    if(myHous.Utility == null)
                    {
                        myHous.UtilitiesCost = 0;
                    }
                    myHous.RenovationCost = (decimal)(myHous.BathroomCost + myHous.ExteriorCost + myHous.InteriorCost + myHous.KitchenCost + myHous.UtilitiesCost);
                    List<int> houseID = new List<int>();
                   foreach(MyHous house in db.MyHouses)
                    {
                        houseID.Add(house.ID);
                    }

                    int highestID = houseID.Max();
                   
                    myHous.ID = highestID + 1;
                    
                    auser.MyHouses.Add(myHous);
                    db.MyHouses.Add(myHous);

                }

            }

            db.SaveChanges();
            return RedirectToAction("Index");


            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.ID = new SelectList(db.Bathrooms, "ID", "ID", myHous.ID);
            ViewBag.ID = new SelectList(db.Exteriors, "ID", "ID", myHous.ID);
            ViewBag.ID = new SelectList(db.Interiors, "ID", "ID", myHous.ID);
            ViewBag.ID = new SelectList(db.Kitchens, "ID", "ID", myHous.ID);
            ViewBag.ID = new SelectList(db.Utilities, "ID", "ID", myHous.ID);
            return View(myHous);
        }

        // GET: MyHous/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyHous myHous = db.MyHouses.Find(id);
            if (myHous == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.ID = new SelectList(db.Bathrooms, "ID", "ID", myHous.ID);
            ViewBag.ID = new SelectList(db.Exteriors, "ID", "ID", myHous.ID);
            ViewBag.ID = new SelectList(db.Interiors, "ID", "ID", myHous.ID);
            ViewBag.ID = new SelectList(db.Kitchens, "ID", "ID", myHous.ID);
            ViewBag.ID = new SelectList(db.Utilities, "ID", "ID", myHous.ID);
            return View(myHous);
        }

        // POST: MyHous/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,StreetNumber,StreetName,City,LotSize,SquareFootage,Stories,BedroomCount,BathroomCount,RoomCount,RenovationCost,BathroomCost,ExteriorCost,InteriorCost,KitchenCost,UtilitiesCost")] MyHous myHous)
        {
            if (ModelState.IsValid)
            {
                db.Entry(myHous).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.ID = new SelectList(db.Bathrooms, "ID", "ID", myHous.ID);
            ViewBag.ID = new SelectList(db.Exteriors, "ID", "ID", myHous.ID);
            ViewBag.ID = new SelectList(db.Interiors, "ID", "ID", myHous.ID);
            ViewBag.ID = new SelectList(db.Kitchens, "ID", "ID", myHous.ID);
            ViewBag.ID = new SelectList(db.Utilities, "ID", "ID", myHous.ID);
            return View(myHous);
        }

        // GET: MyHous/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyHous myHous = db.MyHouses.Find(id);
            if (myHous == null)
            {
                return HttpNotFound();
            }
            return View(myHous);
        }

        // POST: MyHous/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MyHous myHous = db.MyHouses.Find(id);
            db.MyHouses.Remove(myHous);
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
